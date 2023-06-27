using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Api.Repository.Repository.Generic.Interface
{
    public interface IRepositoryGenericMongo<T> where T : class
    {
        T SingleFindBy(FilterDefinition<T> entity);

        IEnumerable<T> FindBy(FilterDefinition<T> entity);
        Task<List<T>> FindByAsync(FilterDefinition<T> entity);
        long CoutFindBy(FilterDefinition<T> entity);

        void Insert(T entity);
        Task InsertAsync(T entity);

        void Update(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity);
        IMongoCollection<T> Get(string collection);
    }
}
