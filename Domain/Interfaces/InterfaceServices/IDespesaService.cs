using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IDespesaService
    {
        Task AdicionarDespesa(Despesa despesa);
        Task AtualizarDespesas(Despesa despesa);
        Task CarregarGraficos(string emailUsuario);
    }
}
