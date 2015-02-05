using HaVaData;
using PopulateSqlData.ReadMeta.Domain;
using PopulateSqlData.ReadMeta.Domain.Column;
using PopulateSqlData.ReadMeta.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopulateSqlData.ReadMeta
{
    public class PopulateManager
    {
        public List<Table> SchemaTables { get; set; }

        public void LoadTables()
        {
            SchemaTables = SchemaUtils.ReadSchemaTables();
            Task.Factory.StartNew(() =>
            {
                foreach (var table in SchemaTables)
                {
                    Task.Factory.StartNew(() =>
                    {
                        table.Status = 1;
                        table.Columns = SchemaUtils.ReadSchemaColumn(table.Name);
                        table.Status = 2;
                    });
                }
            });
        }

        public List<ColumnBase> LoadColumns(Table table)
        {
            if (table.Status == 2 || table.Columns.Count > 0)
                return table.Columns;
            table.Status = 1;
            table.Columns = SchemaUtils.ReadSchemaColumn(table.Name);
            table.Status = 2;
            return table.Columns;
        }

        public DataTable LoadDefaultData(Table table)
        {
            var mDt = new DataTable();
            Sql.Fill(GetSelectQuery(table), mDt);
            return mDt;
        }
        public void StoreSetting(Table table)
        {
            var file = Path.Combine(Application.StartupPath, table.Name + ".setting");
            JsonUtils.Save(table, file);
        }
        public void GenerateData(Table table, DataTable mDt)
        {
            Debug.Print(String.Format("Load schema table for: {0}, records to generate: {1}", table.Name, table.MaxRecords));
            Sql.Fill(GetSelectQuery(table), mDt);
            var numRecsPerThread = 50;
            var threadCount = Math.Max(1,table.MaxRecords / numRecsPerThread);            
            var tasks = new Task[threadCount];
            var total = 0;
            for (int i = 1; i <= threadCount; i++)
            {
                var tmp = i + ":" + DateTime.Now.Millisecond.ToString();
                Debug.Print("Start thread: " + tmp);
                tasks[i - 1] = Task.Factory.StartNew(() =>
                {
                    var mDt1 = mDt.Copy();
                    for (int j = 1; j <= numRecsPerThread; j++)
                    {
                        table.Generate(mDt1);
                    }
                    Save2Sql(table, mDt1);
                    Debug.Print("Thread {0} has stopped, current records: {1}", tmp, mDt1.Rows.Count);
                    total += mDt1.Rows.Count;
                    mDt1.Dispose();
                });
            }
            Task.WaitAll(tasks);
            Debug.Print("Total generated records:" + total);
        }

        public void Save2Sql(Table table, DataTable mDt)
        {
            Sql.Update(GetSelectQuery(table), mDt);
        }

        public String GetSelectQuery(Table table)
        {
            return String.Format("Select top 0 * From {0}", table.Name);
        }
    }
}
