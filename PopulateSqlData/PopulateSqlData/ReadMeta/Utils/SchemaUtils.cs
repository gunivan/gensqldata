
using HaVaData;
using PopulateSqlData.ReadMeta.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaVaUtils;
using PopulateSqlData.ReadMeta.Domain.Column;
using PopulateSqlData.ReadMeta.Domain.Setting;

namespace PopulateSqlData.ReadMeta.Utils
{
    public static class SchemaUtils
    {
        #region DataType
        private static Dictionary<String, int> MAP_DATA_TYPE = new Dictionary<string, int>(){
            {"char",0}, {"varchar", 0}, {"text",0}, {"nchar",0}, {"nvarchar", 0}, {"ntext", 0},
            {"date", 1}, {"datetime", 1}, {"datetime2", 1}, {"smalldatetime", 1}, {"datetimeoffset", 1},
            {"time", 2}, 
            {"int", 3}, {"float", 3}, {"smallint", 3}, {"tinyint", 3},
            {"decimal", 4}, {"smallmoney", 4}, {"bigint",4}, {"money",4}, {"numeric",4}, {"real", 4},
            {"bit", 5}, {"uniqueidentifier", 6}
        };
        private static Dictionary<int, GenerateDataType> MAP_GEN_TYPE = new Dictionary<int, GenerateDataType>(){
            {0, GenerateDataType.String},
            {1, GenerateDataType.DateTime},
            {2, GenerateDataType.Time},
            {3, GenerateDataType.Int},
            {4, GenerateDataType.Long},
            {5, GenerateDataType.Bit},
            {6, GenerateDataType.Uid}
        };
        #endregion

        public static List<Table> ReadSchemaTables()
        {
            LogUtils.Logs.Log("Begin load schemaTable");
            //Lấy ra tất cả bảng         
            var query = @"SELECT A.TABLE_NAME, B.CHILD FROM                 
                (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE') A 
                LEFT OUTER JOIN
                (SELECT DISTINCT OBJECT_NAME(referenced_object_id) PARENT, 
                               OBJECT_NAME(parent_object_id) CHILD 
                FROM sys.foreign_key_columns) B
                ON A.TABLE_NAME = B.PARENT
                ORDER BY A.TABLE_NAME";

            var table = new DataTable();
            Sql.Fill(query, table);
            var tableList = new List<Table>();

            foreach (DataRow row in table.Rows)
            {
                var tableParent = FieldUtils.AsText(row, "TABLE_NAME");
                var tableChild = FieldUtils.AsText(row, "CHILD");

                var parent = tableList.FirstOrDefault(tb => tb.Name.Equals(tableParent));
                if (null == parent)
                {
                    parent = new Table(tableParent);
                    tableList.Add(parent);
                }

                if (!String.IsNullOrEmpty(tableChild))
                {
                    var child = tableList.FirstOrDefault(tb => tb.Name.Equals(tableChild));
                    if (null == child)
                    {
                        child = new Table(tableChild);
                        tableList.Add(child);
                    }
                    parent.Children.Add(child);
                }
            }
            LogUtils.Logs.Log("Completed load schema table:{0} tables", tableList.Count);
            foreach (var tbl in tableList)
            {
                LogUtils.Logs.Log(tbl.ToString());
            }
            return tableList;
        }

        public static List<ColumnBase> ReadSchemaColumn(String tableName)
        {
            LogUtils.Logs.Log("Begin reading schema column for table:{0}", tableName);
            var query = String.Format(@"SELECT C.*,RK.CNST_NAME, RK.PARENT_COL, RK.PARENT, ISPK, ISUK, UKNAME  
                           FROM  
                                       (SELECT COLUMN_NAME ,IS_NULLABLE ,  DATA_TYPE, 
                                               CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_PRECISION_RADIX 
                                       FROM INFORMATION_SCHEMA.COLUMNS   
                                       WHERE TABLE_NAME= '{0}') AS C 
                           LEFT OUTER JOIN 
                                       (SELECT DISTINCT OBJECT_NAME(constraint_object_id) CNST_NAME,COL_NAME(parent_object_id, parent_column_id ) AS CHILD_COL, 
                                                         COL_NAME(referenced_object_id, referenced_column_id ) AS  PARENT_COL, 
                                                         OBJECT_NAME(referenced_object_id) AS PARENT 
                                       FROM sys.foreign_key_columns 
                                       WHERE OBJECT_NAME(parent_object_id) = '{0}')	AS RK 
                           ON C.COLUMN_NAME = RK.CHILD_COL 
                           LEFT OUTER JOIN 
                                       (SELECT  COLUMN_NAME, 
                                       OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'IsPrimaryKey') ISPK  
                                       FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE  
                                       WHERE TABLE_NAME='{0}' AND  OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'IsPrimaryKey') = 1) AS PK  
                           ON C.COLUMN_NAME = PK.COLUMN_NAME  
                           LEFT OUTER JOIN  
                                       (SELECT  COLUMN_NAME,  CONSTRAINT_NAME AS UKNAME , 
                                       OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'IsUniqueCnst') ISUK 
                                       FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE  
                                       WHERE TABLE_NAME='{0}' AND OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'IsUniqueCnst') = 1) AS UK 
                           ON C.COLUMN_NAME = UK.COLUMN_NAME", tableName);
            var table = new DataTable();
            Sql.Fill(query, table);
            var columnList = new List<ColumnBase>();

            foreach (DataRow row in table.Rows)
            {
                var isPk = FieldUtils.AsInt(row, "ISPK") == 1;
                var isUk = FieldUtils.AsInt(row, "ISUK") == 1;
                var isRef = !String.IsNullOrEmpty(FieldUtils.AsText(row, "PARENT_COL"));
                ColumnBase column = null;
                if ((isPk || isUk) && !isRef)
                    column = new PrimaryColumn();
                else if (isRef)
                    column = new ReferenceColumn();
                else
                    column = new NormalColumn();

                column.Name = FieldUtils.AsText(row, "COLUMN_NAME"); ;
                column.UniqueName = FieldUtils.AsText(row, "UKNAME");
                column.DataTypeName = FieldUtils.AsText(row, "DATA_TYPE");
                column.MaxLength = FieldUtils.AsInt(row, "CHARACTER_MAXIMUM_LENGTH");
                column.NumPrecision = FieldUtils.AsByte(row, "NUMERIC_PRECISION");
                column.NumPrecisionRadix = FieldUtils.AsInt16(row, "NUMERIC_PRECISION_RADIX");
                column.GenType = GetGenerateType(column.DataTypeName);
                var setting = default(GenSetting);
                switch (column.GenType)
                {
                    case GenerateDataType.String:
                        setting = new GenStringSetting();
                        break;
                    case GenerateDataType.DateTime:
                        setting = new GenDateTimeSetting();
                        break;
                    case GenerateDataType.Time:
                        setting = new GenDateTimeSetting();
                        break;
                    case GenerateDataType.Int:
                        setting = new GenNumSetting();
                        break;
                    case GenerateDataType.Long:
                        setting = new GenNumSetting();
                        break;
                    case GenerateDataType.Bit:
                        setting = new GenBitSetting();
                        break;
                    case GenerateDataType.Uid:
                        setting = new GenSetting();
                        break;
                    default:
                        setting = new GenSetting();
                        break;
                }
                column.Setting = setting;
                if (column.ColType.GetType() == typeof(NormalColumn))
                {
                    column.CanNull = FieldUtils.AsBool(row, "IS_NULLABLE");
                }
                else
                {
                    var refCol = column as ReferenceColumn;
                    if (null != refCol)
                    {
                        refCol.CnstName = FieldUtils.AsText(row, "CNST_NAME");
                        refCol.RefTableName = FieldUtils.AsText(row, "PARENT");
                        refCol.RefColumnName = FieldUtils.AsText(row, "PARENT_COL");
                    }
                }
                columnList.Add(column);
            }
            LogUtils.Logs.Log("End reading schema column, table:{0}, {1} columns", tableName, columnList.Count);
            return columnList;
        }

        private static GenerateDataType GetGenerateType(String dataTypeName)
        {
            if (!MAP_DATA_TYPE.ContainsKey(dataTypeName))
                return GenerateDataType.String;
            var index = MAP_DATA_TYPE[dataTypeName];
            return MAP_GEN_TYPE[index];
        }
    }
}
