namespace SQL_Manager
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TbQuery = new System.Windows.Forms.TextBox();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.DgResults = new System.Windows.Forms.DataGridView();
            this.LbMessage = new System.Windows.Forms.Label();
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.lb = new System.Windows.Forms.Label();
            this.LbTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // TbQuery
            // 
            this.TbQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbQuery.Location = new System.Drawing.Point(50, 87);
            this.TbQuery.Multiline = true;
            this.TbQuery.Name = "TbQuery";
            this.TbQuery.Size = new System.Drawing.Size(631, 268);
            this.TbQuery.TabIndex = 0;
            // 
            // BtnExecute
            // 
            this.BtnExecute.BackgroundImage = global::SQL_Manager.Properties.Resources.Execute5;
            this.BtnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExecute.Location = new System.Drawing.Point(621, 13);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(137, 49);
            this.BtnExecute.TabIndex = 1;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // DgResults
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgResults.Location = new System.Drawing.Point(50, 361);
            this.DgResults.Name = "DgResults";
            this.DgResults.RowHeadersWidth = 51;
            this.DgResults.RowTemplate.Height = 24;
            this.DgResults.Size = new System.Drawing.Size(1303, 287);
            this.DgResults.TabIndex = 2;
            // 
            // LbMessage
            // 
            this.LbMessage.AutoSize = true;
            this.LbMessage.Location = new System.Drawing.Point(712, 271);
            this.LbMessage.Name = "LbMessage";
            this.LbMessage.Size = new System.Drawing.Size(0, 17);
            this.LbMessage.TabIndex = 3;
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(50, 28);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(226, 24);
            this.CbDatabases.TabIndex = 4;
            this.CbDatabases.SelectedIndexChanged += new System.EventHandler(this.CbDatabases_SelectedIndexChanged);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(714, 307);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(116, 17);
            this.lb.TabIndex = 5;
            this.lb.Text = "Completion time: ";
            // 
            // LbTime
            // 
            this.LbTime.AutoSize = true;
            this.LbTime.Location = new System.Drawing.Point(836, 307);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(0, 17);
            this.LbTime.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1405, 676);
            this.Controls.Add(this.LbTime);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.CbDatabases);
            this.Controls.Add(this.LbMessage);
            this.Controls.Add(this.DgResults);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.TbQuery);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DgResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbQuery;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.DataGridView DgResults;
        private System.Windows.Forms.Label LbMessage;
        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label LbTime;
    }
}

