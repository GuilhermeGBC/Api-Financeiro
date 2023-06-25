using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaService(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataCadastro = DateTime.Now;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);
        }

        public async Task AtualizarDespesas(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Update(despesa);
        }

        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            var despesasUsuario = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
            var despesasAnteriores = await _interfaceDespesa.ListarDespesasNaoPagasMesesAnteriores(emailUsuario);

            var despesas_NaoPagasMesesAnteriores = despesasAnteriores.Any() ?
                despesasAnteriores.ToList().Sum(x => x.Valor) : 0;

            var despesas_pagas = despesasUsuario.Where(x => x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var despesas_pendentes = despesasUsuario.Where(x => !x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(x => x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesas_pagas,
                despesas_pendentes = despesas_pendentes,
                despesas_naoPagasMesesAnteriores = despesas_NaoPagasMesesAnteriores,
                investimentos = investimentos
            };
        }
    }
}
