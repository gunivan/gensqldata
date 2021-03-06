﻿using System.Windows.Forms;
namespace PopulateSqlData
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnServer = new System.Windows.Forms.Button();
            this.gvData = new PopulateSqlData.MGridView();
            this.loadingTable = new HaVaControl.LoadingCircle();
            this.loadingGrid = new HaVaControl.LoadingCircle();
            this.grGenString = new System.Windows.Forms.GroupBox();
            this.radGenStringRegex = new System.Windows.Forms.RadioButton();
            this.txtGenStringRegex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radGenStringRandom = new System.Windows.Forms.RadioButton();
            this.radGenStringCollections = new System.Windows.Forms.RadioButton();
            this.radGenStringIdentity = new System.Windows.Forms.RadioButton();
            this.numGenStringRandomTo = new System.Windows.Forms.NumericUpDown();
            this.numGenStringRandomFrom = new System.Windows.Forms.NumericUpDown();
            this.txtGenStringCollections = new System.Windows.Forms.TextBox();
            this.txtGenStringIdentity = new System.Windows.Forms.TextBox();
            this.grGenBit = new System.Windows.Forms.GroupBox();
            this.radGenBitRandom = new System.Windows.Forms.RadioButton();
            this.radGenBitFalse = new System.Windows.Forms.RadioButton();
            this.radGenBitTrue = new System.Windows.Forms.RadioButton();
            this.grGenDatetime = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpGenDateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtpGenDateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.grGenNumber = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numGenNumStart = new System.Windows.Forms.NumericUpDown();
            this.radGenNumRandom = new System.Windows.Forms.RadioButton();
            this.radGenNumStartWith = new System.Windows.Forms.RadioButton();
            this.numGenNumRandomTo = new System.Windows.Forms.NumericUpDown();
            this.numGenNumRandomFrom = new System.Windows.Forms.NumericUpDown();
            this.grGenByDataColumn = new System.Windows.Forms.GroupBox();
            this.chkGenFromTable = new System.Windows.Forms.CheckBox();
            this.cbColumns = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lvColumn = new System.Windows.Forms.ListView();
            this.Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numGenRecords = new System.Windows.Forms.NumericUpDown();
            this.btnSave2Sql = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrace = new System.Windows.Forms.TextBox();
            this.btnSelectData = new System.Windows.Forms.Button();
            this.loadingColumns = new HaVaControl.LoadingCircle();
            this.btnTestRegex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.grGenString.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenStringRandomTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenStringRandomFrom)).BeginInit();
            this.grGenBit.SuspendLayout();
            this.grGenDatetime.SuspendLayout();
            this.grGenNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumRandomTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumRandomFrom)).BeginInit();
            this.grGenByDataColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(4, 30);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(233, 367);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(3, 4);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(233, 23);
            this.btnServer.TabIndex = 1;
            this.btnServer.Text = "Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // gvData
            // 
            this.gvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvData.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvData.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gvData.Location = new System.Drawing.Point(883, 156);
            this.gvData.Name = "gvData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.gvData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gvData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvData.RowTemplate.Height = 26;
            this.gvData.Size = new System.Drawing.Size(407, 240);
            this.gvData.TabIndex = 2;
            this.gvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvData_ColumnHeaderMouseClick);
            // 
            // loadingTable
            // 
            this.loadingTable.Active = false;
            this.loadingTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingTable.BackColor = System.Drawing.Color.Transparent;
            this.loadingTable.Color = System.Drawing.Color.DarkTurquoise;
            this.loadingTable.InnerCircleRadius = 5;
            this.loadingTable.Location = new System.Drawing.Point(170, 200);
            this.loadingTable.Name = "loadingTable";
            this.loadingTable.NumberSpoke = 12;
            this.loadingTable.OuterCircleRadius = 11;
            this.loadingTable.ParentAnchor = this;
            this.loadingTable.RotationSpeed = 100;
            this.loadingTable.Size = new System.Drawing.Size(41, 28);
            this.loadingTable.SpokeThickness = 2;
            this.loadingTable.StylePreset = HaVaControl.LoadingCircle.StylePresets.MacOSX;
            this.loadingTable.TabIndex = 3;
            this.loadingTable.Text = "loadingCircle1";
            this.loadingTable.Visible = false;
            // 
            // loadingGrid
            // 
            this.loadingGrid.Active = false;
            this.loadingGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingGrid.BackColor = System.Drawing.Color.Transparent;
            this.loadingGrid.Color = System.Drawing.Color.DarkTurquoise;
            this.loadingGrid.InnerCircleRadius = 5;
            this.loadingGrid.Location = new System.Drawing.Point(960, 319);
            this.loadingGrid.Name = "loadingGrid";
            this.loadingGrid.NumberSpoke = 12;
            this.loadingGrid.OuterCircleRadius = 11;
            this.loadingGrid.ParentAnchor = this;
            this.loadingGrid.RotationSpeed = 100;
            this.loadingGrid.Size = new System.Drawing.Size(41, 28);
            this.loadingGrid.SpokeThickness = 2;
            this.loadingGrid.StylePreset = HaVaControl.LoadingCircle.StylePresets.MacOSX;
            this.loadingGrid.TabIndex = 4;
            this.loadingGrid.Text = "loadingCircle2";
            this.loadingGrid.Visible = false;
            // 
            // grGenString
            // 
            this.grGenString.Controls.Add(this.radGenStringRegex);
            this.grGenString.Controls.Add(this.txtGenStringRegex);
            this.grGenString.Controls.Add(this.label3);
            this.grGenString.Controls.Add(this.radGenStringRandom);
            this.grGenString.Controls.Add(this.radGenStringCollections);
            this.grGenString.Controls.Add(this.radGenStringIdentity);
            this.grGenString.Controls.Add(this.numGenStringRandomTo);
            this.grGenString.Controls.Add(this.numGenStringRandomFrom);
            this.grGenString.Controls.Add(this.txtGenStringCollections);
            this.grGenString.Controls.Add(this.txtGenStringIdentity);
            this.grGenString.Location = new System.Drawing.Point(938, -1);
            this.grGenString.Name = "grGenString";
            this.grGenString.Size = new System.Drawing.Size(356, 114);
            this.grGenString.TabIndex = 5;
            this.grGenString.TabStop = false;
            this.grGenString.Text = "String";
            // 
            // radGenStringRegex
            // 
            this.radGenStringRegex.AutoSize = true;
            this.radGenStringRegex.Location = new System.Drawing.Point(14, 89);
            this.radGenStringRegex.Name = "radGenStringRegex";
            this.radGenStringRegex.Size = new System.Drawing.Size(56, 17);
            this.radGenStringRegex.TabIndex = 10;
            this.radGenStringRegex.Text = "Regex";
            this.radGenStringRegex.UseVisualStyleBackColor = true;
            // 
            // txtGenStringRegex
            // 
            this.txtGenStringRegex.Location = new System.Drawing.Point(109, 87);
            this.txtGenStringRegex.Name = "txtGenStringRegex";
            this.txtGenStringRegex.Size = new System.Drawing.Size(241, 20);
            this.txtGenStringRegex.TabIndex = 9;
            this.txtGenStringRegex.Text = "[0-9a-zA-Z]{20}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "to";
            // 
            // radGenStringRandom
            // 
            this.radGenStringRandom.AutoSize = true;
            this.radGenStringRandom.Checked = true;
            this.radGenStringRandom.Location = new System.Drawing.Point(14, 65);
            this.radGenStringRandom.Name = "radGenStringRandom";
            this.radGenStringRandom.Size = new System.Drawing.Size(88, 17);
            this.radGenStringRandom.TabIndex = 7;
            this.radGenStringRandom.TabStop = true;
            this.radGenStringRandom.Text = "Random from";
            this.radGenStringRandom.UseVisualStyleBackColor = true;
            // 
            // radGenStringCollections
            // 
            this.radGenStringCollections.AutoSize = true;
            this.radGenStringCollections.Location = new System.Drawing.Point(14, 40);
            this.radGenStringCollections.Name = "radGenStringCollections";
            this.radGenStringCollections.Size = new System.Drawing.Size(76, 17);
            this.radGenStringCollections.TabIndex = 6;
            this.radGenStringCollections.Text = "Collections";
            this.radGenStringCollections.UseVisualStyleBackColor = true;
            // 
            // radGenStringIdentity
            // 
            this.radGenStringIdentity.AutoSize = true;
            this.radGenStringIdentity.Location = new System.Drawing.Point(15, 18);
            this.radGenStringIdentity.Name = "radGenStringIdentity";
            this.radGenStringIdentity.Size = new System.Drawing.Size(85, 17);
            this.radGenStringIdentity.TabIndex = 5;
            this.radGenStringIdentity.Text = "String identiy";
            this.radGenStringIdentity.UseVisualStyleBackColor = true;
            // 
            // numGenStringRandomTo
            // 
            this.numGenStringRandomTo.Location = new System.Drawing.Point(246, 64);
            this.numGenStringRandomTo.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGenStringRandomTo.Name = "numGenStringRandomTo";
            this.numGenStringRandomTo.Size = new System.Drawing.Size(105, 20);
            this.numGenStringRandomTo.TabIndex = 4;
            this.numGenStringRandomTo.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numGenStringRandomTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numGenStringRandom_MouseClick);
            // 
            // numGenStringRandomFrom
            // 
            this.numGenStringRandomFrom.Location = new System.Drawing.Point(109, 63);
            this.numGenStringRandomFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGenStringRandomFrom.Name = "numGenStringRandomFrom";
            this.numGenStringRandomFrom.Size = new System.Drawing.Size(105, 20);
            this.numGenStringRandomFrom.TabIndex = 3;
            this.numGenStringRandomFrom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGenStringRandomFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numGenStringRandom_MouseClick);
            // 
            // txtGenStringCollections
            // 
            this.txtGenStringCollections.Location = new System.Drawing.Point(110, 40);
            this.txtGenStringCollections.Name = "txtGenStringCollections";
            this.txtGenStringCollections.Size = new System.Drawing.Size(241, 20);
            this.txtGenStringCollections.TabIndex = 1;
            this.txtGenStringCollections.Text = "CH001,CH002";
            this.txtGenStringCollections.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGenString_MouseClick);
            // 
            // txtGenStringIdentity
            // 
            this.txtGenStringIdentity.Location = new System.Drawing.Point(110, 18);
            this.txtGenStringIdentity.Name = "txtGenStringIdentity";
            this.txtGenStringIdentity.Size = new System.Drawing.Size(241, 20);
            this.txtGenStringIdentity.TabIndex = 0;
            this.txtGenStringIdentity.Text = "M00000000001";
            this.txtGenStringIdentity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGenString_MouseClick);
            // 
            // grGenBit
            // 
            this.grGenBit.Controls.Add(this.radGenBitRandom);
            this.grGenBit.Controls.Add(this.radGenBitFalse);
            this.grGenBit.Controls.Add(this.radGenBitTrue);
            this.grGenBit.Location = new System.Drawing.Point(242, -1);
            this.grGenBit.Name = "grGenBit";
            this.grGenBit.Size = new System.Drawing.Size(231, 36);
            this.grGenBit.TabIndex = 6;
            this.grGenBit.TabStop = false;
            this.grGenBit.Text = "Bit";
            // 
            // radGenBitRandom
            // 
            this.radGenBitRandom.AutoSize = true;
            this.radGenBitRandom.Checked = true;
            this.radGenBitRandom.Location = new System.Drawing.Point(150, 13);
            this.radGenBitRandom.Name = "radGenBitRandom";
            this.radGenBitRandom.Size = new System.Drawing.Size(77, 17);
            this.radGenBitRandom.TabIndex = 2;
            this.radGenBitRandom.TabStop = true;
            this.radGenBitRandom.Text = "True/False";
            this.radGenBitRandom.UseVisualStyleBackColor = true;
            // 
            // radGenBitFalse
            // 
            this.radGenBitFalse.AutoSize = true;
            this.radGenBitFalse.Location = new System.Drawing.Point(84, 14);
            this.radGenBitFalse.Name = "radGenBitFalse";
            this.radGenBitFalse.Size = new System.Drawing.Size(50, 17);
            this.radGenBitFalse.TabIndex = 1;
            this.radGenBitFalse.Text = "False";
            this.radGenBitFalse.UseVisualStyleBackColor = true;
            // 
            // radGenBitTrue
            // 
            this.radGenBitTrue.AutoSize = true;
            this.radGenBitTrue.Location = new System.Drawing.Point(31, 14);
            this.radGenBitTrue.Name = "radGenBitTrue";
            this.radGenBitTrue.Size = new System.Drawing.Size(47, 17);
            this.radGenBitTrue.TabIndex = 0;
            this.radGenBitTrue.Text = "True";
            this.radGenBitTrue.UseVisualStyleBackColor = true;
            // 
            // grGenDatetime
            // 
            this.grGenDatetime.Controls.Add(this.label2);
            this.grGenDatetime.Controls.Add(this.label1);
            this.grGenDatetime.Controls.Add(this.dtpGenDateTimeTo);
            this.grGenDatetime.Controls.Add(this.dtpGenDateTimeFrom);
            this.grGenDatetime.Location = new System.Drawing.Point(243, 40);
            this.grGenDatetime.Name = "grGenDatetime";
            this.grGenDatetime.Size = new System.Drawing.Size(230, 75);
            this.grGenDatetime.TabIndex = 7;
            this.grGenDatetime.TabStop = false;
            this.grGenDatetime.Text = "Datetime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From ";
            // 
            // dtpGenDateTimeTo
            // 
            this.dtpGenDateTimeTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpGenDateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGenDateTimeTo.Location = new System.Drawing.Point(68, 44);
            this.dtpGenDateTimeTo.Name = "dtpGenDateTimeTo";
            this.dtpGenDateTimeTo.Size = new System.Drawing.Size(158, 20);
            this.dtpGenDateTimeTo.TabIndex = 1;
            // 
            // dtpGenDateTimeFrom
            // 
            this.dtpGenDateTimeFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpGenDateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGenDateTimeFrom.Location = new System.Drawing.Point(68, 19);
            this.dtpGenDateTimeFrom.Name = "dtpGenDateTimeFrom";
            this.dtpGenDateTimeFrom.Size = new System.Drawing.Size(158, 20);
            this.dtpGenDateTimeFrom.TabIndex = 0;
            // 
            // grGenNumber
            // 
            this.grGenNumber.Controls.Add(this.label4);
            this.grGenNumber.Controls.Add(this.numGenNumStart);
            this.grGenNumber.Controls.Add(this.radGenNumRandom);
            this.grGenNumber.Controls.Add(this.radGenNumStartWith);
            this.grGenNumber.Controls.Add(this.numGenNumRandomTo);
            this.grGenNumber.Controls.Add(this.numGenNumRandomFrom);
            this.grGenNumber.Location = new System.Drawing.Point(477, -1);
            this.grGenNumber.Name = "grGenNumber";
            this.grGenNumber.Size = new System.Drawing.Size(251, 116);
            this.grGenNumber.TabIndex = 8;
            this.grGenNumber.TabStop = false;
            this.grGenNumber.Text = "Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "to";
            // 
            // numGenNumStart
            // 
            this.numGenNumStart.Location = new System.Drawing.Point(113, 17);
            this.numGenNumStart.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGenNumStart.Name = "numGenNumStart";
            this.numGenNumStart.Size = new System.Drawing.Size(129, 20);
            this.numGenNumStart.TabIndex = 17;
            this.numGenNumStart.ThousandsSeparator = true;
            this.numGenNumStart.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGenNumStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numGenNumStart_MouseClick);
            // 
            // radGenNumRandom
            // 
            this.radGenNumRandom.AutoSize = true;
            this.radGenNumRandom.Location = new System.Drawing.Point(17, 48);
            this.radGenNumRandom.Name = "radGenNumRandom";
            this.radGenNumRandom.Size = new System.Drawing.Size(88, 17);
            this.radGenNumRandom.TabIndex = 14;
            this.radGenNumRandom.Text = "Random from";
            this.radGenNumRandom.UseVisualStyleBackColor = true;
            // 
            // radGenNumStartWith
            // 
            this.radGenNumStartWith.AutoSize = true;
            this.radGenNumStartWith.Checked = true;
            this.radGenNumStartWith.Location = new System.Drawing.Point(17, 20);
            this.radGenNumStartWith.Name = "radGenNumStartWith";
            this.radGenNumStartWith.Size = new System.Drawing.Size(47, 17);
            this.radGenNumStartWith.TabIndex = 13;
            this.radGenNumStartWith.TabStop = true;
            this.radGenNumStartWith.Text = "Start";
            this.radGenNumStartWith.UseVisualStyleBackColor = true;
            // 
            // numGenNumRandomTo
            // 
            this.numGenNumRandomTo.Location = new System.Drawing.Point(113, 72);
            this.numGenNumRandomTo.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGenNumRandomTo.Name = "numGenNumRandomTo";
            this.numGenNumRandomTo.Size = new System.Drawing.Size(129, 20);
            this.numGenNumRandomTo.TabIndex = 12;
            this.numGenNumRandomTo.ThousandsSeparator = true;
            this.numGenNumRandomTo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numGenNumRandomTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numGenNumRandom_MouseClick);
            // 
            // numGenNumRandomFrom
            // 
            this.numGenNumRandomFrom.Location = new System.Drawing.Point(113, 47);
            this.numGenNumRandomFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGenNumRandomFrom.Name = "numGenNumRandomFrom";
            this.numGenNumRandomFrom.Size = new System.Drawing.Size(129, 20);
            this.numGenNumRandomFrom.TabIndex = 11;
            this.numGenNumRandomFrom.ThousandsSeparator = true;
            this.numGenNumRandomFrom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGenNumRandomFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numGenNumRandom_MouseClick);
            // 
            // grGenByDataColumn
            // 
            this.grGenByDataColumn.Controls.Add(this.chkGenFromTable);
            this.grGenByDataColumn.Controls.Add(this.cbColumns);
            this.grGenByDataColumn.Controls.Add(this.label6);
            this.grGenByDataColumn.Controls.Add(this.cbTables);
            this.grGenByDataColumn.Controls.Add(this.label5);
            this.grGenByDataColumn.Location = new System.Drawing.Point(734, -1);
            this.grGenByDataColumn.Name = "grGenByDataColumn";
            this.grGenByDataColumn.Size = new System.Drawing.Size(198, 115);
            this.grGenByDataColumn.TabIndex = 10;
            this.grGenByDataColumn.TabStop = false;
            // 
            // chkGenFromTable
            // 
            this.chkGenFromTable.AutoSize = true;
            this.chkGenFromTable.Location = new System.Drawing.Point(49, 15);
            this.chkGenFromTable.Name = "chkGenFromTable";
            this.chkGenFromTable.Size = new System.Drawing.Size(75, 17);
            this.chkGenFromTable.TabIndex = 8;
            this.chkGenFromTable.Text = "From table";
            this.chkGenFromTable.UseVisualStyleBackColor = true;
            // 
            // cbColumns
            // 
            this.cbColumns.FormattingEnabled = true;
            this.cbColumns.Location = new System.Drawing.Point(49, 70);
            this.cbColumns.Name = "cbColumns";
            this.cbColumns.Size = new System.Drawing.Size(143, 21);
            this.cbColumns.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Column";
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(49, 44);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(143, 21);
            this.cbTables.TabIndex = 5;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Table";
            // 
            // lvColumn
            // 
            this.lvColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvColumn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column});
            this.lvColumn.FullRowSelect = true;
            this.lvColumn.HideSelection = false;
            this.lvColumn.Location = new System.Drawing.Point(242, 156);
            this.lvColumn.Name = "lvColumn";
            this.lvColumn.Size = new System.Drawing.Size(136, 241);
            this.lvColumn.TabIndex = 11;
            this.lvColumn.UseCompatibleStateImageBehavior = false;
            this.lvColumn.View = System.Windows.Forms.View.Details;
            this.lvColumn.SelectedIndexChanged += new System.EventHandler(this.lvColumn_SelectedIndexChanged);
            // 
            // Column
            // 
            this.Column.Width = 130;
            // 
            // numGenRecords
            // 
            this.numGenRecords.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGenRecords.Location = new System.Drawing.Point(311, 126);
            this.numGenRecords.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numGenRecords.Name = "numGenRecords";
            this.numGenRecords.Size = new System.Drawing.Size(82, 20);
            this.numGenRecords.TabIndex = 12;
            this.numGenRecords.ThousandsSeparator = true;
            this.numGenRecords.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnSave2Sql
            // 
            this.btnSave2Sql.Location = new System.Drawing.Point(403, 120);
            this.btnSave2Sql.Name = "btnSave2Sql";
            this.btnSave2Sql.Size = new System.Drawing.Size(105, 29);
            this.btnSave2Sql.TabIndex = 13;
            this.btnSave2Sql.Text = "Save To Database";
            this.btnSave2Sql.UseVisualStyleBackColor = true;
            this.btnSave2Sql.Click += new System.EventHandler(this.btnSave2Sql_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Records";
            // 
            // txtTrace
            // 
            this.txtTrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrace.Location = new System.Drawing.Point(384, 156);
            this.txtTrace.Multiline = true;
            this.txtTrace.Name = "txtTrace";
            this.txtTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTrace.Size = new System.Drawing.Size(493, 240);
            this.txtTrace.TabIndex = 15;
            // 
            // btnSelectData
            // 
            this.btnSelectData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectData.Location = new System.Drawing.Point(514, 120);
            this.btnSelectData.Name = "btnSelectData";
            this.btnSelectData.Size = new System.Drawing.Size(105, 29);
            this.btnSelectData.TabIndex = 16;
            this.btnSelectData.Text = "Load data";
            this.btnSelectData.UseVisualStyleBackColor = true;
            this.btnSelectData.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // loadingColumns
            // 
            this.loadingColumns.Active = false;
            this.loadingColumns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingColumns.BackColor = System.Drawing.Color.Transparent;
            this.loadingColumns.Color = System.Drawing.Color.DarkTurquoise;
            this.loadingColumns.InnerCircleRadius = 5;
            this.loadingColumns.Location = new System.Drawing.Point(276, 279);
            this.loadingColumns.Name = "loadingColumns";
            this.loadingColumns.NumberSpoke = 12;
            this.loadingColumns.OuterCircleRadius = 11;
            this.loadingColumns.ParentAnchor = this;
            this.loadingColumns.RotationSpeed = 100;
            this.loadingColumns.Size = new System.Drawing.Size(41, 28);
            this.loadingColumns.SpokeThickness = 2;
            this.loadingColumns.StylePreset = HaVaControl.LoadingCircle.StylePresets.MacOSX;
            this.loadingColumns.TabIndex = 17;
            this.loadingColumns.Text = "loadingCircle2";
            this.loadingColumns.Visible = false;
            // 
            // btnTestRegex
            // 
            this.btnTestRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestRegex.Location = new System.Drawing.Point(938, 117);
            this.btnTestRegex.Name = "btnTestRegex";
            this.btnTestRegex.Size = new System.Drawing.Size(105, 29);
            this.btnTestRegex.TabIndex = 18;
            this.btnTestRegex.Text = "Test Regex";
            this.btnTestRegex.UseVisualStyleBackColor = true;
            this.btnTestRegex.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 401);
            this.Controls.Add(this.btnTestRegex);
            this.Controls.Add(this.loadingColumns);
            this.Controls.Add(this.btnSelectData);
            this.Controls.Add(this.txtTrace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave2Sql);
            this.Controls.Add(this.numGenRecords);
            this.Controls.Add(this.grGenString);
            this.Controls.Add(this.lvColumn);
            this.Controls.Add(this.grGenByDataColumn);
            this.Controls.Add(this.grGenNumber);
            this.Controls.Add(this.grGenDatetime);
            this.Controls.Add(this.grGenBit);
            this.Controls.Add(this.loadingGrid);
            this.Controls.Add(this.loadingTable);
            this.Controls.Add(this.gvData);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.Text = "Populate Sql Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.grGenString.ResumeLayout(false);
            this.grGenString.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenStringRandomTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenStringRandomFrom)).EndInit();
            this.grGenBit.ResumeLayout(false);
            this.grGenBit.PerformLayout();
            this.grGenDatetime.ResumeLayout(false);
            this.grGenDatetime.PerformLayout();
            this.grGenNumber.ResumeLayout(false);
            this.grGenNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumRandomTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenNumRandomFrom)).EndInit();
            this.grGenByDataColumn.ResumeLayout(false);
            this.grGenByDataColumn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView treeView1;
        private Button btnServer;
        private MGridView gvData;
        private HaVaControl.LoadingCircle loadingTable;
        private HaVaControl.LoadingCircle loadingGrid;
        private GroupBox grGenNumber;
        private GroupBox grGenDatetime;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpGenDateTimeTo;
        private DateTimePicker dtpGenDateTimeFrom;
        private GroupBox grGenBit;
        private RadioButton radGenBitRandom;
        private RadioButton radGenBitFalse;
        private RadioButton radGenBitTrue;
        private GroupBox grGenString;
        private Label label3;
        private RadioButton radGenStringRandom;
        private RadioButton radGenStringCollections;
        private RadioButton radGenStringIdentity;
        private NumericUpDown numGenStringRandomTo;
        private NumericUpDown numGenStringRandomFrom;
        private TextBox txtGenStringCollections;
        private TextBox txtGenStringIdentity;
        private NumericUpDown numGenNumStart;
        private RadioButton radGenNumRandom;
        private RadioButton radGenNumStartWith;
        private NumericUpDown numGenNumRandomTo;
        private NumericUpDown numGenNumRandomFrom;
        private Label label4;
        private GroupBox grGenByDataColumn;
        private ComboBox cbColumns;
        private Label label6;
        private ComboBox cbTables;
        private Label label5;
        private ListView lvColumn;
        private ColumnHeader Column;
        private CheckBox chkGenFromTable;
        private NumericUpDown numGenRecords;
        private Button btnSave2Sql;
        private Label label7;
        private TextBox txtTrace;
        private Button btnSelectData;
        private HaVaControl.LoadingCircle loadingColumns;
        private RadioButton radGenStringRegex;
        private TextBox txtGenStringRegex;
        private Button btnTestRegex;
    }
}

