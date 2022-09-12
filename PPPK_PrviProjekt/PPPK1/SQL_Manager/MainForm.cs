using SQL_Manager.dal;
using SQL_Manager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Manager
{
    public partial class MainForm : Form
    {
        private const string Select = "select";
        private const string Insert = "insert";
        private const string Update = "update";
        private const string Delete = "delete";
        private Database currentDatabase = new Database();
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() => CbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());

        private void CbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDatabase = CbDatabases.SelectedItem as Database;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            string[] stmts = TbQuery.Text.Trim().Split(';');

            foreach (var stmt in stmts)
            {
                try
                {
                    DataSet ds = RepositoryFactory.GetRepository().CreateDataSet(stmt, currentDatabase);

                    if (stmt.Contains(Select))
                    {

                        DgResults.DataSource = ds.Tables[0];
                        LbMessage.Text = "(" + ds.Tables[0].Rows.Count + " rows affected )";
                        LbTime.Text = DateTime.Now.ToString();

                    }
                    else if (stmt.Contains(Insert))
                    {

                        DgResults.DataSource = ds;
                        LbMessage.Text = "Inserted successfully";
                        LbTime.Text = DateTime.Now.ToString();

                    }
                    else if (stmt.Contains(Update))
                    {

                        DgResults.DataSource = ds;
                        LbMessage.Text = "Updated successfully";
                        LbTime.Text = DateTime.Now.ToString();

                    }
                    else if (stmt.Contains(Delete))
                    {

                        DgResults.DataSource = ds;
                        LbMessage.Text = "Deleted successfully";
                        LbTime.Text = DateTime.Now.ToString();

                    }
                    else
                    {
                        DgResults.DataSource = ds;
                        LbMessage.Text = "Completed successfully";
                        LbTime.Text = DateTime.Now.ToString();
                    }
                }
                catch (Exception ex)
                {

                    LbMessage.Text = ex.Message;
                } 
            }

        }

        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        
    }
}
