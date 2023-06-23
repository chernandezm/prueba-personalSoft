using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xolit.Api.Repository.Repository.Generic.Interface;

namespace Xolit.Api.Repository.Repository.Generic.Service
{
    public class RepositoryGenericMongo<T> : IRepositoryGenericMongo<T> where T : class
    {
        protected readonly string connectionString;
        private readonly IConfiguration configuration;
        private IMongoDatabase mongoDatabase;
        private IMongoCollection<T> mongoCollection;
        private readonly MongoClient client;

        public RepositoryGenericMongo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("MongoConnection");
            this.client = new MongoClient(this.connectionString);
        }

        public long CoutFindBy(FilterDefinition<T> entity)
        {
            return this.mongoCollection.CountDocuments(entity);
        }

        public IEnumerable<T> FindBy(FilterDefinition<T> entity)
        {
            return this.mongoCollection.Find<T>(entity).ToList();
        }

        public async Task<List<T>> FindByAsync(FilterDefinition<T> entity)
        {
            return await (await this.mongoCollection.FindAsync<T>(entity)).ToListAsync();
        }

        public void Insert(T entity)
        {
            this.mongoCollection.InsertOne(entity);
        }

        public Task InsertAsync(T entity)
        {
            try
            {
                return this.mongoCollection.InsertOneAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public T SingleFindBy(FilterDefinition<T> entity)
        {
            return this.mongoCollection.Find<T>(entity).FirstOrDefault();
        }

        public void Update(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            this.mongoCollection.UpdateOne(filter, entity);
        }

        public Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            return this.mongoCollection.UpdateOneAsync(filter, entity);
        }

        private string GetDatabase()
        {
            var databaseName = this.configuration.GetSection("DbNames").GetSection("MongoDb");
            if (databaseName == null) throw new ArgumentNullException("DbNames.Mongo", "No Database name found in appsettings");

            return databaseName.Value;
        }

        public IMongoCollection<T> Get(string collection)
        {
            this.mongoDatabase = this.client.GetDatabase(this.GetDatabase());
            this.mongoCollection = this.mongoDatabase.GetCollection<T>(collection);
            return this.mongoCollection;
        }
    }
}
