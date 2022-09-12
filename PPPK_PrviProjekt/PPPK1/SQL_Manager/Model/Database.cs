using SQL_Manager.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Manager.Model
{
    class Database
    {
        private readonly Lazy<IEnumerable<DBEntity>> tables; //1. lazy naloadan definiramo (zelimo dati tablice tek kada me netko pita, a ne u konstruktoru odmah naloadat)
        private readonly Lazy<IEnumerable<DBEntity>> views;
        private readonly Lazy<IEnumerable<Procedure>> procedures;
        public Database()
        {
           tables = new Lazy<IEnumerable<DBEntity>>(() => RepositoryFactory.GetRepository().GetDBEntities(this, DBEntityType.Table));//3. ako je prazno okida se i dohvaca tablice ako netko pita!
           views = new Lazy<IEnumerable<DBEntity>>(() => RepositoryFactory.GetRepository().GetDBEntities(this, DBEntityType.View));
           procedures = new Lazy<IEnumerable<Procedure>>(() => RepositoryFactory.GetRepository().GetProcedures(this));
        }
        public IList<DBEntity> Tables
        {
            get => new List<DBEntity>(tables.Value); //2. .Value zbog lazy
        }
        public IList<DBEntity> Views
        {
            get => new List<DBEntity>(views.Value);
        }
        public IList<Procedure> Procedures
        {
            get => new List<Procedure>(procedures.Value);
        }
        public string Name { get; set; } 
        public override string ToString() => Name;
    }

}
