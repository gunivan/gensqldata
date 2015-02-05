using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopulateSqlData.ReadMeta;
using PopulateSqlData.ReadMeta.Domain;
using PopulateSqlData.ReadMeta.Domain.Column;
using PopulateSqlData.ReadMeta.Domain.Setting;
namespace PopulateSqlData
{
    public partial class Form1 : Form
    {
        PopulateManager manager = new PopulateManager();
        Table currentTable;
        ColumnBase currentColumn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingTable.ParentAnchor = treeView1;
            loadingGrid.ParentAnchor = gvData;
            LoadTable();
        }
        void LoadTable()
        {
            this.Execute(() =>
            {
                Utils.VisibleLoading(loadingTable);
                manager.LoadTables();
            }).ContinueWith((data) =>
            {
                treeView1.ExeInvoke(() =>
                {
                    treeView1.Nodes.Clear();
                    foreach (var table in manager.SchemaTables)
                    {
                        var node = treeView1.Nodes.Add(table.Name, table.Name);
                        node.Tag = table;
                    }
                });
                Utils.VisibleLoading(loadingTable, false);
                this.Execute(() =>
                {
                    cbTables.ExeInvoke(() =>
                    {
                        cbTables.Items.AddRange(manager.SchemaTables.Select(tbl => tbl.Name).ToArray());
                    });
                });
            });
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            var f = new FormServer();
            f.ShowDialog();
            LoadTable();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (null == e.Node)
                return;
            if (e.Node.Tag is Table)
            {
                var table = e.Node.Tag as Table;
                if (null != table)
                {
                    currentTable = table;
                    Utils.VisibleLoading(loadingTable);
                    if (e.Node.Checked)
                    {
                        LoadColumns(table, e.Node);
                        LoadDefaultData(table);
                    }
                    else
                    {
                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            node.Checked = e.Node.Checked;
                        }
                        Utils.VisibleLoading(loadingTable, false);
                    }
                }
            }
            else if (e.Node.Tag is ColumnBase)
            {
                var column = e.Node.Tag as ColumnBase;
                if (null != column)
                {
                    column.IsGen = e.Node.Checked;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1_AfterCheck(sender, e);
        }
        void LoadColumns(Table table, TreeNode parent)
        {
            this.Execute(() =>
            {
                var columnList = manager.LoadColumns(table);
                lvColumn.ExeInvoke(() =>
                {
                    lvColumn.Items.Clear();
                });
                treeView1.ExeInvoke(() =>
                {
                    treeView1.SuspendLayout();
                    parent.Nodes.Clear();
                    foreach (var col in columnList)
                    {
                        var node = parent.Nodes.Add(col.Name, col.Name);
                        node.Tag = col;
                        node.Checked = true;
                        lvColumn.ExeInvoke(() =>
                        {
                            lvColumn.Items.Add(col.Name);
                        });
                    }
                    parent.Expand();
                    treeView1.ResumeLayout();
                });
                Utils.VisibleLoading(loadingTable, false);
            });
        }

        void LoadDefaultData(Table table)
        {
            this.Execute(() =>
           {
               Utils.VisibleLoading(loadingGrid);
               gvData.ExeInvoke(() =>
               {
                   gvData.DataSource = manager.LoadDefaultData(table);
               });
               Utils.VisibleLoading(loadingGrid, false);
           });
        }
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (null == currentTable)
                return;
            var colName = gvData.Columns[e.ColumnIndex].Name;
            var column = currentTable.Columns.FirstOrDefault(col => col.Name.Equals(colName));
            if (null == column)
                return;
            SaveColumnSetting(currentTable, currentColumn);
            currentColumn = column;
            LoadGenInfor(currentTable, column);
        }

        private void lvColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == currentTable)
                return;
            if (null == lvColumn.FocusedItem)
                return;
            var colName = lvColumn.FocusedItem.Text;
            var column = currentTable.Columns.FirstOrDefault(col => col.Name.Equals(colName));
            if (null == column)
                return;
            SaveColumnSetting(currentTable, currentColumn);
            currentColumn = column;
            LoadGenInfor(currentTable, column);
        }
        void LoadGenInfor(Table table, ColumnBase column)
        {
            switch (column.GenType)
            {
                case GenerateDataType.String:
                    {
                        var setting = column.Setting as GenStringSetting;
                        if (null != setting)
                        {
                            radGenStringIdentity.Checked = setting.IsIdentity;
                            radGenStringCollections.Checked = setting.IsCollections;
                            radGenNumRandom.Checked = setting.IsRandom;
                            if (setting.IsIdentity)
                            {
                                txtGenStringIdentity.Text = setting.Value;
                            }
                            if (setting.IsCollections)
                            {
                                txtGenStringCollections.Text = setting.Value;
                            }
                            if (setting.IsRandom)
                            {
                                numGenStringRandomFrom.Value = setting.Min;
                                numGenStringRandomTo.Value = setting.Max;
                            }
                        }
                    }
                    break;
                case GenerateDataType.DateTime:
                    {
                        var setting = column.Setting as GenDateTimeSetting;
                        if (null != setting)
                        {
                            dtpGenDateTimeFrom.Value = setting.Min;
                            dtpGenDateTimeTo.Value = setting.Max;
                        }
                    }
                    break;
                case GenerateDataType.Time:
                    {
                        var setting = column.Setting as GenDateTimeSetting;
                        if (null != setting)
                        { }
                    }
                    break;
                case GenerateDataType.Int:
                case GenerateDataType.Long:                    
                    {
                        var setting = column.Setting as GenNumSetting;
                        if (null != setting)
                        {
                            radGenNumRandom.Checked = setting.IsRandom;
                            radGenNumStartWith.Checked = !setting.IsRandom;
                            numGenNumStart.Value = setting.Min;
                            numGenNumRandomFrom.Value = setting.Min;
                            numGenNumRandomTo.Value = setting.Max;
                        }
                    }
                    break;
                case GenerateDataType.Bit:
                    {
                        var setting = column.Setting as GenBitSetting;
                        if (null != setting)
                        {
                            radGenBitRandom.Checked = setting.IsRandom;
                            if (!setting.IsRandom)
                            {
                                if (setting.Value)
                                {
                                    radGenBitTrue.Checked = true;
                                }
                                else
                                {
                                    radGenBitFalse.Checked = false;
                                }
                            }
                        }
                    }
                    break;
                case GenerateDataType.Uid:
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        void SaveColumnSetting(Table table, ColumnBase column)
        {
            if (null == column)
                return;

            switch (column.GenType)
            {
                case GenerateDataType.String:
                    {
                        var setting = column.Setting as GenStringSetting;
                        if (null != setting)
                        {
                            setting.IsIdentity = radGenStringIdentity.Checked;
                            setting.IsCollections = radGenStringCollections.Checked;
                            setting.IsRandom = radGenNumRandom.Checked;
                            if (setting.IsIdentity)
                            {
                                setting.Value = txtGenStringIdentity.Text;
                            }
                            if (setting.IsCollections)
                            {
                                setting.Value = txtGenStringCollections.Text;
                            }
                            if (setting.IsRandom)
                            {
                                setting.Min = (int)numGenStringRandomFrom.Value;
                                setting.Max = (int)numGenStringRandomTo.Value;
                            }
                        }
                    }
                    break;
                case GenerateDataType.DateTime:
                    {
                        var setting = column.Setting as GenDateTimeSetting;
                        if (null != setting)
                        {
                            setting.Min = dtpGenDateTimeFrom.Value;
                            setting.Max = dtpGenDateTimeTo.Value;
                        }
                    }
                    break;
                case GenerateDataType.Time:
                    {
                        var setting = column.Setting as GenDateTimeSetting;
                        if (null != setting)
                        {
                            setting.Min = dtpGenDateTimeFrom.Value;
                            setting.Max = dtpGenDateTimeTo.Value;
                        }
                    }
                    break;
                case GenerateDataType.Int:
                case GenerateDataType.Long:
                    {
                        var setting = column.Setting as GenNumSetting;
                        if (null != setting)
                        {
                            setting.IsRandom = radGenNumRandom.Checked;
                            setting.Min = numGenNumRandomFrom.Value;
                            setting.Max = numGenNumRandomTo.Value;
                            if (!setting.IsRandom)
                            {
                                setting.Min = numGenNumStart.Value;
                                setting.Max += setting.Min + numGenRecords.Value;
                            }
                        }
                    }
                    break;
                case GenerateDataType.Bit:
                    {
                        var setting = column.Setting as GenBitSetting;
                        if (null != setting)
                        {
                            setting.IsRandom = radGenBitRandom.Checked;
                            setting.Value = radGenBitTrue.Checked;
                        }
                    }
                    break;
                case GenerateDataType.Uid:
                    {                         
                    }
                    break;
                default:
                    break;
            }
        }
       
        #region Set Radio Check
        private void txtGenString_MouseClick(object sender, MouseEventArgs e)
        {
            var txt = sender as TextBox;
            if (txtGenStringIdentity.Name.Equals(txt.Name))
            {
                radGenStringIdentity.Checked = true;
            }
            else if (txtGenStringCollections.Name.Equals(txt.Name))
            {
                radGenStringCollections.Checked = true;
            }
        }

        private void numGenStringRandom_MouseClick(object sender, MouseEventArgs e)
        {
            radGenStringRandom.Checked = true;
        }

        private void numGenNumStart_MouseClick(object sender, MouseEventArgs e)
        {
            radGenNumStartWith.Checked = true;
        }

        private void numGenNumRandom_MouseClick(object sender, MouseEventArgs e)
        {
            radGenNumRandom.Checked = true;
        }
        #endregion

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var table = manager.SchemaTables.FirstOrDefault(t => t.Name.Equals(cbTables.Text));
            if (null == table)
                return;
            var node = default(TreeNode);
            var arrNode = treeView1.Nodes.Find(table.Name, false);
            if (arrNode != null && arrNode.Length > 0)
                node = arrNode[0];
            if (null != node)
            {
                node.Checked = true;
            }
            var items = table.Columns.Select(c => c.Name).ToArray();
            cbColumns.Items.Clear();
            cbColumns.Items.AddRange(items);
            lvColumn.Items.Clear();
            foreach (var item in items)
            {
                lvColumn.Items.Add(item);
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            Utils.VisibleLoading(loadingGrid);
            this.Execute(() =>
            {
                manager.StoreSetting(currentTable);
            });
            this.Execute(() =>
            {
                var table = manager.LoadDefaultData(currentTable);
                gvData.ExeInvoke(() =>
                {
                    gvData.DataSource = table;
                });
                currentTable.MaxRecords = (int)numGenRecords.Value;
                manager.GenerateData(currentTable, table);
                Utils.VisibleLoading(loadingGrid, false);
            });
        }

        private void btnSave2Sql_Click(object sender, EventArgs e)
        {
            Utils.VisibleLoading(loadingGrid);
            manager.Save2Sql(currentTable, gvData.DataSource as DataTable);
            Utils.VisibleLoading(loadingGrid, false);
        }

    }
}
