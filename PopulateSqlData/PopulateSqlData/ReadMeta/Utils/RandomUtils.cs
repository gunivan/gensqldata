using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Utils
{
    public class RandomUtils
    {
        private static int LENGHT_SHA256 = 64;
        public static String NextString(int length)
        {
            var guid = Guid.NewGuid();
            if (length <= 32)
            {
                return guid.ToString("N").Substring(0, length);
            }
            else
            {
                if (length <= LENGHT_SHA256)
                {
                    return HaVaUtils.CryptUtil.Sha256Encode(guid.ToString()).Substring(0, length);
                }
                else
                {
                    var sb = new StringBuilder(length);
                    sb.Append(HaVaUtils.CryptUtil.Sha256Encode(guid.ToString()));
                    guid = Guid.NewGuid();
                    while (sb.Length < length)
                    {
                        if (sb.Length + LENGHT_SHA256 < length)
                        {
                            sb.Append(HaVaUtils.CryptUtil.Sha256Encode(guid.ToString()));
                        }
                        else
                        {
                            var s = HaVaUtils.CryptUtil.Sha256Encode(guid.ToString());
                            sb.Append(s.Substring(0, length - sb.Length));
                        }
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
