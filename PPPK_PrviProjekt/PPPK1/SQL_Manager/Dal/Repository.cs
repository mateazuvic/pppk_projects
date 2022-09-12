using SQL_Manager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Manager
{
    class Repository : IRepository
    {
        private static string cs;

        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name from sys.databases";
        private const string SelectTables = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.TABLES"; //za dohvacanje tablica
        private const string SelectViews = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.VIEWS"; //za dohvacanje vieweva
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";


        public void Connect(string server, string login, string password)
        {
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionString, server, login, password)))
            {
                cs = con.ConnectionString;
                con.Open();
            }
        }

        public IEnumerable<Database> GetDatabases() //IEnumerable - nesto sto se moze iterirati
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand()) //otvaramo komandu (kao u Javi statement)
                {
                    cmd.CommandText = SelectDatabases;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Database //yield ide s IEnumerable
                            {
                                Name = dr[nameof(Database.Name)].ToString()  //pitamo klasu kako se zove property, u ssmsu trebamo namjestit da se zovu kolone isto kao i propsi (linija 14 as Name)

                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType entityType) //dohvacamo dbEntitete u sta spadaju tablice i viewovi (dbEntiti je visa klasa)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    switch (entityType)
                    {
                        case DBEntityType.Table:
                            cmd.CommandText = string.Format(SelectTables, database.Name); //ako su tablice izvrsi ovo
                            break;
                        case DBEntityType.View:
                            cmd.CommandText = string.Format(SelectViews, database.Name); //ako su viewevi izvrsi ovu komandu
                            break;

                    }
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new DBEntity
                            {
                                Name = dr[nameof(DBEntity.Name)].ToString(),
                                Schema = dr[nameof(DBEntity.Schema)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedures, database.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Procedure
                            {
                                Name = dr[nameof(Procedure.Name)].ToString(),
                                Definition = dr[nameof(Procedure.Definition)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Column> GetColumns(DBEntity entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectColumns, entity.Database.Name, entity.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Column
                            {
                                Name = dr[nameof(Column.Name)].ToString(),
                                DataType = dr[nameof(Column.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Parameter> GetParameters(Procedure procedure)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedureParameters, procedure.Database.Name, procedure.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Parameter
                            {
                                Name = dr[nameof(Parameter.Name)].ToString(),
                                Mode = dr[nameof(Parameter.Mode)].ToString(),
                                DataType = dr[nameof(Parameter.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }


        public DataSet CreateDataSet(string stmt, Database database)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "USE " + database.Name + "\n" + stmt;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;

                    }

                }

            }



        }


    }
}





