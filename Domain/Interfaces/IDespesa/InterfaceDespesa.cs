using Domain.Interfaces.IGenerics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGenerics<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);
        Task<IList<Despesa>> ListarDespesasNaoPagasMesesAnteriores(string emailUsuario);
    }
}
