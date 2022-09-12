using Microsoft.Azure.Cosmos;
using PersonCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonCosmos.Dao
{
    public class CosmosDbService : ICosmosDbService<Person> 
    {
        private readonly Container container; //na njemu su ugradene metode npr CreateItemAsync,...
        public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            container = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task AddAsync(Person obj) => await container.CreateItemAsync(obj, new PartitionKey(obj.Id));


        public async Task DeleteAsync(Person obj) => await container.DeleteItemAsync<Person>(obj.Id, new PartitionKey(obj.Id));


        public async Task<IEnumerable<Person>> GetAllAsync(string queryString)
        {
            List<Person> persons = new List<Person>();
            var query = container.GetItemQueryIterator<Person>(new QueryDefinition(queryString));
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                persons.AddRange(response.ToList());
            }
            return persons;
        }

        public async Task<Person> GetOneAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Person>(id, new PartitionKey(id));
            }
            catch (CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound) //kada je proslijeden id koji ne postoji
            {

                return null;
            }
        }

        public async Task UpdateAsync(Person obj) => await container.UpsertItemAsync(obj, new PartitionKey(obj.Id));

    }
}