using SQL_Manager.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Manager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                RepositoryFactory.GetRepository().Connect(TbServer.Text.Trim(), TbLogin.Text.Trim(), TbPassword.Text.Trim());
                new MainForm().Show();
                Hide();
            }
            catch (Exception ex)
            {

                LbError.Text = ex.Message;
            }
        }
    }
}
