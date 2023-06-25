using Domain.Interfaces.ISistemaFinanceiro;
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
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions _OptionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in db.SistemaFinanceiro
                             join us in db.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                             where us.EmailUsuario.Equals(emailUsuario)
                             select s).AsNoTracking().ToListAsync();                   
            }
        }
    }
}
