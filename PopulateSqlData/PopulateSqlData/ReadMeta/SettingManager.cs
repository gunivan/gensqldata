using HaVaData;
using PopulateSqlData.ReadMeta.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopulateSqlData.ReadMeta
{
    public class SettingManager
    {
        /// <summary>
        /// Store setting file and infor connection of database
        /// </summary>
        public static String DATA_PATH = Path.Combine(Application.StartupPath, "Data");

        /// <summary>
        /// Wrapper database connection infor
        /// </summary>
        public GenerateDatabase generateDatabase;
        String GetFolderSetting(String server, String database)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(server + database));



                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

            }
            return sBuilder.ToString();
        }
        public String GetStoredPath()
        {
            var info = Sql.GetConnectInfor();
            return Path.Combine(DATA_PATH, GetFolderSetting(info.DataSource, info.InitialCatalog));
        }
        public String GetStoredFileName(String tableName)
        {
            var folder = GetStoredPath();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            return Path.Combine(folder, tableName + ".setting");
        }
        public void StoreSetting(Table table)
        {
            var folder = GetStoredPath();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            JsonUtils.Save(table, GetStoredFileName(table.Name));
        }

        public Table LoadSetting(Table table)
        {
            var tmp = JsonUtils.Load<Table>(GetStoredFileName(table.Name));
            if (null != tmp)
            {
                table.Columns.ForEach(item =>
                {
                    var oldCol = tmp.Columns.FirstOrDefault(col => col.Name == item.Name);
                    if (null != oldCol)
                        item.Setting = oldCol.Setting;
                });
            }
            return table;
        }

        public void StoreGenerateDatabase()
        {
            var info = Sql.GetConnectInfor();
            generateDatabase = new GenerateDatabase();
            generateDatabase.Server = info.DataSource;
            generateDatabase.Database = info.InitialCatalog;
            generateDatabase.Username = info.UserID;
            generateDatabase.Password = info.Password;

            if (!Directory.Exists(DATA_PATH))
            {
                Directory.CreateDirectory(DATA_PATH);
            }
            var fileName = GetFolderSetting(generateDatabase.Server, generateDatabase.Database) + ".conf";
            var file = Path.Combine(DATA_PATH, fileName);
            JsonUtils.Save(fileName, Path.Combine(DATA_PATH, "app.conf"));
            JsonUtils.Save(generateDatabase, file);
        }

        public void LoadGenerateDatabase()
        {
            var active = JsonUtils.Load<String>(Path.Combine(DATA_PATH, "app.conf"));
            if (String.IsNullOrEmpty(active))
                return;
            var file = Path.Combine(DATA_PATH, active);
            generateDatabase = JsonUtils.Load<GenerateDatabase>(file);
        }

        public void Load()
        {
            LoadGenerateDatabase();
            if (null == generateDatabase)
            {
                Sql.Init(@".\SQLEXPRESS", "HaVa");
            }
            else
            {
                if (String.IsNullOrEmpty(generateDatabase.Username))
                {
                    Sql.Init(generateDatabase.Server, generateDatabase.Database);
                }
                else
                {
                    Sql.Init(generateDatabase.Server, generateDatabase.Database, generateDatabase.Username, generateDatabase.Password);
                }
            }
        }
    }
}
