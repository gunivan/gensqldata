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
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopulateSqlData.ReadMeta
{
    public class PopulateManager
    {

        /// <summary>
        /// List Schema of Table in database
        /// </summary>
        public List<Table> SchemaTables { get; set; }
        public int LeafLevel { get; set; }
        public void LoadTables()
        {
            var leafLevel = 1;
            SchemaTables = SchemaUtils.ReadSchemaTables(out leafLevel);
            LeafLevel = leafLevel;

            Task.Factory.StartNew(() =>
            {
                foreach (var table in SchemaTables)
                {
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            LoadColumn(table);

                            SchemaUtils.GetRefColumns(table);
                            foreach (var col in table.Columns)
                            {
                                if (!string.IsNullOrEmpty(col.RefColumns))
                                    LogUtils.Logs.Log("Table: {0}, refCols :{1}", col.Name, col.RefColumns);
                            }
                        }
                        catch (Exception e)
                        {
                            LogUtils.Logs.Error(e.Message);
                        }
                    });
                }
            });
        }

        public DataTable LoadData(Table table, int row = 0)
        {
            var mDt = new DataTable();
            Sql.Fill(GetSelectQuery(table, row), mDt);
            return mDt;
        }

        public List<ColumnBase> LoadColumns(Table table)
        {
            if (table.Status == 2 || table.Columns.Count > 0)
                return table.Columns;
            LoadColumn(table);
            return table.Columns;
        }
        void LoadColumn(Table table)
        {
            Log("Start load schema for table: {0}", table.Name);
            table.Status = 1;
            table.Columns = SchemaUtils.ReadSchemaColumn(table.Name);
            table.Status = 2;
            Log("End load schema for table: {0}, columns: {1}, total row: {2}", table.Name, table.Columns.Count, Sql.GetRowCount(table.Name));
        }

        public void GenerateData(Table table)
        {
            Log("Load schema table for: {0}, records to generate: {1}", table.Name, table.MaxRecords);
            var sw = new Stopwatch();
            sw.Start();
            var mDt = new DataTable();
            Sql.Fill(GetSelectQuery(table), mDt);
            var numRecsPerThread = 50;
            var threadCount = Math.Max(1, table.MaxRecords / numRecsPerThread);
            var tasks = new Task[threadCount];
            var total = 0;
            for (int i = 1; i <= threadCount; i++)
            {
                var tmp = i + ":" + DateTime.Now.Millisecond.ToString();
                Log("Start thread: " + tmp);
                tasks[i - 1] = Task.Factory.StartNew(() =>
                {
                    var mDt1 = mDt.Copy();
                    try
                    {
                        for (int j = 1; j <= numRecsPerThread; j++)
                        {
                            table.Generate(mDt1);
                        }
                        Save2Sql(table, mDt1);
                        total += mDt1.Rows.Count;
                        Log("Thread {0} has stopped, current records: {1}", tmp, total);
                        mDt1.Dispose();
                    }
                    catch (Exception e)
                    {
                        Log("Thread {0} has stopped, row generated: {1}, cause: {2}, ", tmp, mDt1.Rows.Count, e.Message);
                    }
                });
            }
            Task.WaitAll(tasks);
            sw.Stop();
            var sp = new TimeSpan(sw.ElapsedTicks);
            Log("Total generated records:{0}, total time: {1}", total, sp.ToString("hh\\:mm\\:ss"));
        }

        public void Save2Sql(Table table, DataTable mDt)
        {
            Sql.Update(GetSelectQuery(table), mDt);
        }

        public String GetSelectQuery(Table table, int record = 0)
        {
            return String.Format("Select top {1} * From [{0}]", table.Name, record);
        }

        private void Log(string msg, params object[] param)
        {
            Debug.Print(String.Format("[{0}] {1}", DateTime.Now.ToString(@"yy/MM/dd HH:mm:ss"), String.Format(msg, param)));
        }
    }
}
