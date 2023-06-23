using Domain.Interfaces.IGenerics;
using Infraestructure.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repo.Generics
{
    public class RepositoryGenerics<TEntity> : InterfaceGenerics<TEntity>, IDisposable where TEntity : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder = new();

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(TEntity obj)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                await db.Set<TEntity>().AddAsync(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity obj)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                db.Set<TEntity>().Remove(obj);
                await db.SaveChangesAsync();
            }
        }


        public async Task<TEntity> GetEntityById(int id)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
              return await db.Set<TEntity>().FindAsync(id);
            }
        }

        public Task<List<TEntity>> List()
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {

            }
        }

        public Task Update(TEntity obj)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            //if (disposing)
            //    return;

            //if (disposing)
            //{
            //    handle.Dispose();
            //    // Free any other managed objects here.
            //    //
            //}

            //disposed = true;
        }
    }
}
