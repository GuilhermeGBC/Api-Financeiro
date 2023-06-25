using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceira;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroService : IUsuarioSistemaFinanceiroService
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceSistemaFinanceiro;

        public UsuarioSistemaFinanceiroService(InterfaceUsuarioSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
                await _interfaceSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
            
        }
    }
}
