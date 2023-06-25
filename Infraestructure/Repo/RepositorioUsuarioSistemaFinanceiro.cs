using Domain.Interfaces.IUsuarioSistemaFinanceira;
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
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await db.UsuarioSistemaFinanceiro
                              .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                              .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuariosPorEmail(string emailUsuario)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await db.UsuarioSistemaFinanceiro
                    .AsNoTracking().FirstOrDefaultAsync(s => s.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuariosSistema(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                db.UsuarioSistemaFinanceiro.RemoveRange(usuarios);
                await db.SaveChangesAsync();
            }
        }
    }
}
