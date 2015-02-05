namespace PopulateSqlData
{
    partial class FormServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.btnReLoadServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkWindowMode = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadingData = new HaVaControl.LoadingCircle();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(96, 19);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(197, 21);
            this.cbServer.TabIndex = 0;
            this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(96, 52);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(254, 21);
            this.cbDatabase.TabIndex = 1;
            // 
            // btnReLoadServer
            // 
            this.btnReLoadServer.Location = new System.Drawing.Point(299, 19);
            this.btnReLoadServer.Name = "btnReLoadServer";
            this.btnReLoadServer.Size = new System.Drawing.Size(51, 23);
            this.btnReLoadServer.TabIndex = 2;
            this.btnReLoadServer.Text = "Reload";
            this.btnReLoadServer.UseVisualStyleBackColor = true;
            this.btnReLoadServer.Click += new System.EventHandler(this.btnReLoadServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Database";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 111);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(254, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(96, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(254, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // chkWindowMode
            // 
            this.chkWindowMode.AutoSize = true;
            this.chkWindowMode.Checked = true;
            this.chkWindowMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindowMode.Location = new System.Drawing.Point(96, 83);
            this.chkWindowMode.Name = "chkWindowMode";
            this.chkWindowMode.Size = new System.Drawing.Size(94, 17);
            this.chkWindowMode.TabIndex = 7;
            this.chkWindowMode.Text = "Window mode";
            this.chkWindowMode.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(108, 186);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadingData);
            this.groupBox1.Controls.Add(this.cbServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDatabase);
            this.groupBox1.Controls.Add(this.btnReLoadServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.chkWindowMode);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 175);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // loadingData
            // 
            this.loadingData.Active = false;
            this.loadingData.Color = System.Drawing.Color.DarkGray;
            this.loadingData.InnerCircleRadius = 5;
            this.loadingData.Location = new System.Drawing.Point(187, 71);
            this.loadingData.Name = "loadingData";
            this.loadingData.NumberSpoke = 12;
            this.loadingData.OuterCircleRadius = 11;
            this.loadingData.RotationSpeed = 100;
            this.loadingData.Size = new System.Drawing.Size(36, 29);
            this.loadingData.SpokeThickness = 2;
            this.loadingData.StylePreset = HaVaControl.LoadingCircle.StylePresets.MacOSX;
            this.loadingData.TabIndex = 12;
            this.loadingData.Text = "loading...";
            this.loadingData.Visible = false;
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 214);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Name = "FormServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormServer";
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Button btnReLoadServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkWindowMode;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private HaVaControl.LoadingCircle loadingData;
    }
}