namespace PopulateSqlData
   {
   partial class MGridView
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
         if(disposing && (components != null))
            {
            components.Dispose();
            }
         base.Dispose(disposing);
         }

      #region Component Designer generated code

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
           ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
           this.SuspendLayout();
           // 
           // MGridView
           // 
           this.BackgroundColor = System.Drawing.SystemColors.ControlLight;
           dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
             this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
           this.ColumnHeadersHeight = 32;
           dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
           dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
           dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
           this.DefaultCellStyle = dataGridViewCellStyle2;
           this.GridColor = System.Drawing.SystemColors.ControlLight;
           dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
           dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
           dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
           dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
           dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
           dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
           this.RowsDefaultCellStyle = dataGridViewCellStyle4;
           this.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           this.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
           this.RowTemplate.Height = 26;
           this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.MGridView_EditingControlShowing);
           ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
           this.ResumeLayout(false);

         }

      #endregion
      }
   }
