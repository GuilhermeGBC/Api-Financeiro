using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IGenerics
{
    public interface InterfaceGenerics<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task GetEntityById<TEntity>(int id);
        Task<List<TEntity>> List();
    }
}
