using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Clinic.WebApp.Data.Interfaces
{
    public interface IGenericController<TEntity> where TEntity : class
    {
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetEntityByID(int id);
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(int Id);

    }
}
