using Microsoft.Azure.Cosmos;
using PersonCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonCosmos.Dao
{
    public static class CosmosDbServiceProvider //aka Factory
    {
        private const string DatabaseName = "Persons";
        private const string ContainerName = "Persons";
        private const string Account = "https://cosmos-persons.documents.azure.com:443/"; //URI
        private const string Key = "DficTACHe9zkEcxEKrTQtkyNwJsqlCvX8mndmxeDA2MNpsRlg4Olf7MLQdk3PAcVecwf1LYvMHd7dvv9AbSiAg=="; //PRIMARY KEY
        private static ICosmosDbService<Person> cosmosDbService;
        public static ICosmosDbService<Person> CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient client = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(client, DatabaseName, ContainerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}