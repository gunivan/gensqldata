using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogUtils;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PopulateSqlData
{
    public static class JsonUtils
    {
        public static bool Save(Object obj, string fileName)
        {

            Logs.Log("JsonUtils: Save to file" + fileName);
            DoTryCatch(() =>
            {
                if (!File.Exists(fileName))
                {
                    var fileInfo = new FileInfo(fileName);
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }
                using (var textWriter = new StreamWriter(fileName))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(textWriter, obj, obj.GetType());
                }
            });

            Logs.Log("JsonUtils: End save to file" + fileName);
            return true;
        }

        public static T Load<T>(string fileName)
        {
            Logs.Log("JsonUtils: Load from file:" + fileName);
            var retVal = default(T);

            if (!File.Exists(fileName))
            {
                Logs.Error("File not found !" + fileName);
                return retVal;
            }
            DoTryCatch(() =>
            {
                using (TextReader textReader = new StreamReader(fileName))
                {
                    using (var jsonReader = new JsonTextReader(textReader))
                    {
                        var serializer = new JsonSerializer();
                        retVal = serializer.Deserialize<T>(jsonReader);
                    }
                }
            });
            Logs.Log("JsonUtils: End Load from file:" + fileName);
            return retVal;
        }

        private static void DoTryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Logs.Error(e);
            }
        }
    }
}
