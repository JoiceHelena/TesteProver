using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteProverService.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        void Remove(TEntity obj);

        Task<TEntity> GetById(int id);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

    }
}
