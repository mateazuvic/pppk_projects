namespace SQL_Manager
{
    partial class LoginForm
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnect.Location = new System.Drawing.Point(184, 276);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(179, 54);
            this.BtnConnect.TabIndex = 13;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = false;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TbPassword
            // 
            this.TbPassword.Location = new System.Drawing.Point(128, 212);
            this.TbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.Size = new System.Drawing.Size(302, 24);
            this.TbPassword.TabIndex = 12;
            this.TbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password:";
            // 
            // TbLogin
            // 
            this.TbLogin.Location = new System.Drawing.Point(128, 154);
            this.TbLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbLogin.Name = "TbLogin";
            this.TbLogin.Size = new System.Drawing.Size(302, 24);
            this.TbLogin.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Login:";
            // 
            // TbServer
            // 
            this.TbServer.Location = new System.Drawing.Point(128, 97);
            this.TbServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbServer.Name = "TbServer";
            this.TbServer.Size = new System.Drawing.Size(302, 24);
            this.TbServer.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 38);
            this.label4.TabIndex = 14;
            this.label4.Text = "SQL Server";
            // 
            // LbError
            // 
            this.LbError.AutoSize = true;
            this.LbError.Location = new System.Drawing.Point(52, 359);
            this.LbError.Name = "LbError";
            this.LbError.Size = new System.Drawing.Size(0, 18);
            this.LbError.TabIndex = 15;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SQL_Manager.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(504, 421);
            this.Controls.Add(this.LbError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TbLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbServer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbError;
    }
}