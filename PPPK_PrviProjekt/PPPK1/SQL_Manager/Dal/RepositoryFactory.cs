using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Manager.dal
{
    static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> repository = new Lazy<IRepository>(() => new Repository());
        public static IRepository GetRepository() => repository.Value;
    }
}
