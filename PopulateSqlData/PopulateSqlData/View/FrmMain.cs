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
using System.IO;
using System.Diagnostics;
using HaVaData;
namespace PopulateSqlData
{

    public partial class FrmMain : Form
    {
        PopulateManager manager = new PopulateManager();
        SettingManager settingManager = new SettingManager();
        Table currentTable;
        ColumnBase currentColumn;
        FormServer formServer;
        List<GroupBox> groupList;
        public FrmMain()
        {
            InitializeComponent();
            var txtWriter = new TextBoxWriter(txtTrace);
            Console.SetOut(txtWriter);
            var traceDebugOutput = new TextWriterTraceListener(txtWriter);
            Trace.Listeners.Add(traceDebugOutput);
            txtTrace.MakeDoubleBuffered(true);
            groupList = new List<GroupBox>();
            groupList.Add(grGenBit);
            groupList.Add(grGenDatetime);
            groupList.Add(grGenNumber);
            groupList.Add(grGenString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingTable.ParentAnchor = treeView1;
            loadingGrid.ParentAnchor = gvData;
            loadingColumns.ParentAnchor = lvColumn;
            settingManager.Load();
            LoadTable();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingManager.StoreGenerateDatabase();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (null == formServer)
                formServer = new FormServer();
            formServer.ShowDialog();
            settingManager.StoreGenerateDatabase();
            LoadTable();
        }
        private void btnSelectData_Click(object sender, EventArgs e)
        {
            LoadTempData(100);
        }

        private void btnSave2Sql_Click(object sender, EventArgs e)
        {
            Utils.VisibleLoading(loadingGrid);
            this.Execute(() =>
            {
                settingManager.StoreSetting(currentTable);
            });
            this.Execute(() =>
            {
                currentTable.MaxRecords = (int)numGenRecords.Value;
                manager.GenerateData(currentTable);
                Utils.VisibleLoading(loadingGrid, false);
            });
        }         
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1_AfterCheck(sender, e);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (null == e.Node)
                return;
            LoadSelectedTable(e.Node);
        }

        private void LoadSelectedTable(TreeNode node)
        {
            if (node.Tag is Table)
            {
                var table = node.Tag as Table;
                if (null != table)
                {
                    if (null != currentTable)
                    {
                        currentTable.MaxRecords = (int)numGenRecords.Value;
                    }
                    currentTable = table;
                    Utils.VisibleLoading(loadingTable);
                    settingManager.LoadSetting(table);
                    if (node.Checked)
                    {
                        LoadColumns(table, node);
                        LoadTempData();
                    }
                    else
                    {
                        foreach (TreeNode n in node.Nodes)
                        {
                            n.Checked = node.Checked;
                        }
                    }
                    Utils.VisibleLoading(loadingTable, false);
                }
            }
            else if (node.Tag is ColumnBase)
            {
                var column = node.Tag as ColumnBase;
                if (null != column)
                {
                    column.IsGen = node.Checked;
                }
            }
        }
        void LoadTempData(int row = 0)
        {
            this.Execute(() =>
            {
                Utils.VisibleLoading(loadingGrid);
                gvData.ExeInvoke(() =>
                {
                    gvData.DataSource = manager.LoadData(currentTable, row);
                });
                Utils.VisibleLoading(loadingGrid, false);
            });
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
                    if (treeView1.Nodes.Count > 0)
                    {
                        treeView1.SelectedNode = treeView1.Nodes[0];
                        treeView1.SelectedNode.Checked = true;
                        LoadSelectedTable(treeView1.SelectedNode);
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

        void LoadColumns(Table table, TreeNode parent)
        {
            List<ColumnBase> columnList = new List<ColumnBase>();
            this.Execute(() =>
            {
                Utils.VisibleLoading(loadingColumns);
                Utils.VisibleLoading(loadingTable);
                columnList = manager.LoadColumns(table);
            }).ContinueWith((data) =>
            {
                numGenRecords.ExeInvoke(() =>
                {
                    numGenRecords.Value = currentTable.MaxRecords < 0 ? 1000 : currentTable.MaxRecords;
                });
                this.Execute(() =>
                {
                    treeView1.ExeInvoke(() =>
                    {
                        treeView1.SuspendLayout();
                        parent.Nodes.Clear();
                        foreach (var col in columnList)
                        {
                            var node = parent.Nodes.Add(col.Name, col.Name);
                            node.Tag = col;
                            node.Checked = true;
                        }
                        parent.Expand();
                        treeView1.ResumeLayout();
                    });
                    Utils.VisibleLoading(loadingTable, false);
                });

                this.Execute(() =>
                {
                    lvColumn.ExeInvoke(() =>
                        {
                            lvColumn.SuspendLayout();
                            lvColumn.Items.Clear();
                            foreach (var col in columnList)
                            {
                                lvColumn.Items.Add(col.Name);
                            }
                            lvColumn.ResumeLayout();
                        });
                    Utils.VisibleLoading(loadingColumns, false);
                });
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
            EnableGroup(column.GenType);
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

        void EnableGroup(GenerateDataType genType)
        {
            var group = default(GroupBox);
            switch (genType)
            {
                case GenerateDataType.String:
                    group = grGenString;
                    break;
                case GenerateDataType.DateTime:
                    group = grGenDatetime;
                    break;
                case GenerateDataType.Time:
                    group = grGenDatetime;
                    break;
                case GenerateDataType.Int:
                    group = grGenNumber;
                    break;
                case GenerateDataType.Long:
                    group = grGenNumber;
                    break;
                case GenerateDataType.Bit:
                    group = grGenBit;
                    break;
                case GenerateDataType.Uid:
                    break;
            }
            if (null != group)
            {
                group.Enabled = true;
                foreach (var gr in groupList)
                {
                    if (gr != group)
                        gr.Enabled = false;
                }
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
                            setting.NumType = column.GenType == GenerateDataType.Int ? typeof(Int32).ToString() : typeof(long).ToString();
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
    }
}
