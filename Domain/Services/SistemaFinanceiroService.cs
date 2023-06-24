using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SistemaFinanceiroService : ISistemaFinanceiroService
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceiroService(InterfaceSistemaFinanceiro sistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = sistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
                await _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if(valido)
                await _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
        }
    }
}
