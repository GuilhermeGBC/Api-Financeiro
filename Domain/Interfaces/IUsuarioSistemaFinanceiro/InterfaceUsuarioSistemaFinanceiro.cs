using Domain.Interfaces.IGenerics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUsuarioSistemaFinanceira
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGenerics<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema);
        Task RemoveUsuariosSistema(List<UsuarioSistemaFinanceiro> usuarios);
        Task<UsuarioSistemaFinanceiro> ObterUsuariosPorEmail(string emailUsuario);
    
    }
}
