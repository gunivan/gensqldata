using Newtonsoft.Json;
using PopulateSqlData.ReadMeta.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopulateSqlData.ReadMeta.Domain.Setting;

namespace PopulateSqlData.ReadMeta.Domain.Column
{
    public abstract class ColumnBase
    {
        private static Random random = new Random();

        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("type")]
        public ColumnType ColType { get; set; }
        [JsonIgnore]
        public Table Parent { get; set; }
        [JsonProperty("u_name")]
        public String UniqueName { get; set; }
        [JsonProperty("data_type")]
        public String DataTypeName { get; set; }
        [JsonProperty("max_len")]
        public int MaxLength { get; set; }
        [JsonProperty("can_null")]
        public Boolean CanNull { get; set; }
        [JsonProperty("num_precis")]
        public int NumPrecision { get; set; }
        [JsonProperty("num_precis_radix")]
        public int NumPrecisionRadix { get; set; }
        [JsonProperty("gen_type")]
        public GenerateDataType GenType { get; set; }
        [JsonIgnore]
        public Boolean IsGen { get; set; }
        [JsonProperty("setting")]
        public GenSetting Setting { get; set; }

        [JsonIgnore]
        public object CurrentValue { get; set; }

        [JsonIgnore]
        public bool CanRestartSequence { get; set; }
        public virtual object NextValue()
        {
            object value = null;
            if (Setting is GenNumSetting)
            {
                var setting = Setting as GenNumSetting;
                var type = Type.GetType(setting.NumType);
                if (type == typeof(long))
                {
                    var longValue = null == CurrentValue ? setting.Min : Convert.ToInt64(CurrentValue);
                    if (setting.IsRandom)
                    {
                        value = HaVaUtils.Generator.Next();
                    }
                    else
                    {
                        if (longValue >= setting.Max && CanRestartSequence)
                        {
                            longValue = setting.Min;
                        }
                        value = ++longValue;
                    }
                }
                else
                {
                    var intValue = null == CurrentValue ? setting.Min : Convert.ToInt32(CurrentValue);
                    if (setting.IsRandom)
                    {
                        value = random.Next((int)setting.Min, (int)setting.Max);
                    }
                    else
                    {
                        if (intValue >= setting.Max && CanRestartSequence)
                        {
                            intValue = setting.Min;
                        }
                        value = ++intValue;
                    }
                }
            }
            else if (Setting is GenBitSetting)
            {
                var setting = Setting as GenBitSetting;
                if (setting.IsRandom)
                {
                    value = null == CurrentValue ? true : !Convert.ToBoolean(CurrentValue);
                }
                else
                {
                    value = setting.Value;
                }
            }
            else if (Setting is GenDateTimeSetting)
            {
                var setting = Setting as GenDateTimeSetting;

                var dateTimeValue = null == CurrentValue ? setting.Min : Convert.ToDateTime(CurrentValue);
                if (dateTimeValue >= setting.Max && CanRestartSequence)
                {
                    dateTimeValue = setting.Min;
                }
                value = dateTimeValue.AddDays(1);
            }
            else if (Setting is GenBasedTableSetting)
            {

            }
            else if (Setting is GenStringSetting)
            {
                var setting = Setting as GenStringSetting;
                if (setting.IsIdentity)
                {
                    var template = CurrentValue == null ? setting.Value : CurrentValue.ToString();
                    value = HaVaUtils.StringUtils.StringIdentity(template);
                }
                else if (setting.IsCollections)
                {
                    if (null == setting.TemplateString)
                    {
                        setting.TemplateString = setting.Value.Split(',', ';');
                    }
                    value = setting.TemplateString[random.Next(0, setting.TemplateString.Length)];
                }
                else
                {
                    value = RandomUtils.NextString(random.Next(Math.Min(setting.Min, MaxLength), Math.Min(MaxLength, setting.Max)));
                }
            }
            CurrentValue = value;
            return value;
        }
        public virtual DataRow Generate(DataRow row)
        {
            lock (this)
            {
                var value = NextValue();
                row[Name] = value;
            }
            return row;
        }
    }
}
