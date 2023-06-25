using Domain.Interfaces.IDespesa;
using Entities.Entities;
using Infraestructure.Configuracao;
using Infraestructure.Repo.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repo
{
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioDespesa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Despesa>> ListarDespesasNaoPagasMesesAnteriores(string emailUsuario)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in db.SistemaFinanceiro
                     join c in db.Categoria on s.Id equals c.IdSistema
                     join us in db.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in db.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && d.Pago
                     select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await 
                    (from s in db.SistemaFinanceiro
                     join c in db.Categoria on s.Id equals c.IdSistema
                     join us in db.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in db.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                     select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
