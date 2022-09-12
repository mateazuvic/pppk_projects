using SQL_Manager.Model;
using System.Collections.Generic;
using System.Data;

namespace SQL_Manager
{
    interface IRepository
    {
        void Connect(string server, string login, string password);
        DataSet CreateDataSet(string stmt, Database database);
        IEnumerable<Column> GetColumns(DBEntity entity);
        IEnumerable<Database> GetDatabases();
        IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType entityType);
        IEnumerable<Parameter> GetParameters(Procedure procedure);
        IEnumerable<Procedure> GetProcedures(Database database);
    }
}