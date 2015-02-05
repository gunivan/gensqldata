using HaVaData;
using PopulateSqlData.ReadMeta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopulateSqlData
{
    public partial class FormServer : Form
    {  
        public FormServer()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                Sql.Init(cbServer.Text.Trim(), cbDatabase.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                Sql.Init(cbServer.Text.Trim(), cbDatabase.Text.Trim());
            }
            this.Close();
        }

        private void btnReLoadServer_Click(object sender, EventArgs e)
        {
            LoadServer();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            LoadServer();
        }
        void LoadServer()
        {
            var list = new HashSet<String>();
            this.Execute(() =>
            {
                Utils.VisibleLoading(loadingData);
                var tmp = Sql.GetSqlInstanceByShell();
                foreach (var item in tmp)
                {
                    list.Add(item);
                }
                tmp = Sql.GetSqlInstance();
                foreach (var item in tmp)
                {
                    list.Add(item);
                }
            }).ContinueWith((data) =>
            {
                cbServer.ExeInvoke(() =>
                {
                    cbServer.Items.Clear();
                    cbServer.Items.AddRange(list.ToArray());
                    if (list.Count > 0)
                        cbServer.SelectedIndex = 0;
                });
                Utils.VisibleLoading(loadingData, false);
            });
        }

        void LoadDatabase()
        {
            var list = new List<String>();
            var server = cbServer.Text.Trim();
            var user = txtUserName.Text.Trim();
            var pass = txtPassword.Text.Trim();
            this.Execute(() =>
            {
                if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
                    list = Sql.LoadDatabase(server, user, pass);
                else
                    list = Sql.LoadDatabase(server);
                cbDatabase.ExeInvoke(() =>
                {
                    cbDatabase.Items.Clear();
                    cbDatabase.Items.AddRange(list.ToArray());
                    if (list.Count > 0)
                        cbDatabase.SelectedIndex = 0;
                });
            });
        }
        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatabase();
        }         
    }
}
