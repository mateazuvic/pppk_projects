using PersonManager.Utils;
using PPPK2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    class SqlRepository : IRepository
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        //private static readonly string cs =EncryptionUtils.Decrypt(ConfigurationManager.ConnectionStrings["cs"].ConnectionString, "pa$$w0rd");

        private const string FirstNameParam = "@firstname";
        private const string LastNameParam = "@lastname";
        private const string AgeParam = "@age";
        private const string EmailParam = "@email";
        private const string PictureParam = "@picture";
        private const string IdPersonParam = "@idPerson";

        private const string NameParam = "@name";
        private const string RatingParam = "@rating";
        private const string PersonIdParam = "@personid";
        private const string IdTVShowParam = "@idtvshow";

       

        public void AddPerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name; //pitamo stack u kojoj smo metodi
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);

                    cmd.Parameters.Add( // za sliku
                        new SqlParameter(PictureParam, System.Data.SqlDbType.Binary, person.Picture.Length)
                        {
                            Value = person.Picture
                        });

                    SqlParameter id = new SqlParameter(IdPersonParam, System.Data.SqlDbType.Int) //za output
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    person.IDPerson = (int)id.Value;
                }
            }
        }

        public void UpdatePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.Parameters.Add(
                        new SqlParameter(PictureParam, System.Data.SqlDbType.Binary, person.Picture.Length)
                        {
                            Value = person.Picture
                        });

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public Person GetPerson(int idPerson)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, idPerson);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadPerson(dr);
                        }
                    }
                }
            }
            throw new Exception("Wrong id");
        }

        private Person ReadPerson(SqlDataReader dr)
           => new Person
           {
               IDPerson = (int)dr[nameof(Person.IDPerson)],
               FirstName = dr[nameof(Person.FirstName)].ToString(),
               LastName = dr[nameof(Person.LastName)].ToString(),
               Age = (int)dr[nameof(Person.Age)],
               Email = dr[nameof(Person.Email)].ToString(),
               Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5)
           };


        public IList<Person> GetPeople()
        {
            IList<Person> people = new List<Person>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadPerson(dr));
                        }
                    }
                }
            }
            return people;
        }


        public void AddTVShow(TVShow tvShow)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(NameParam, tvShow.Name);
                    cmd.Parameters.AddWithValue(RatingParam, tvShow.Rating);
                    cmd.Parameters.AddWithValue(PersonIdParam, tvShow.TVHost.IDPerson);


                    SqlParameter id = new SqlParameter(IdTVShowParam, System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    tvShow.IDShow = (int)id.Value;
                }
            }
        }

        public void UpdateTVShow(TVShow tvShow)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(NameParam, tvShow.Name);
                    cmd.Parameters.AddWithValue(RatingParam, tvShow.Rating);
                    cmd.Parameters.AddWithValue(PersonIdParam, tvShow.TVHost.IDPerson);
                    cmd.Parameters.AddWithValue(IdTVShowParam, tvShow.IDShow);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTVShow(TVShow tVShow)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdTVShowParam, tVShow.IDShow);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public TVShow GetTVShow(int idTVShow)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdTVShowParam, idTVShow);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadTVShow(dr);
                        }
                    }
                }
            }
            throw new Exception("Wrong id");
        }

        private TVShow ReadTVShow(SqlDataReader dr)
       => new TVShow
       {
           IDShow = (int)dr[nameof(TVShow.IDShow)],
           Name = dr[nameof(TVShow.Name)].ToString(),
           Rating = (int)dr[nameof(TVShow.Rating)],
           TVHost = GetPerson((int)dr["PersonID"])
       };

        public IList<TVShow> GetTVShows()
        {
            IList<TVShow> tvShows = new List<TVShow>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tvShows.Add(ReadTVShow(dr));
                        }
                    }
                }
            }
            return tvShows;
        }


    }
}
