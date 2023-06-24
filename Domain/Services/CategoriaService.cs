using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly InterfaceCategoria _interfaceCategoria;

        public CategoriaService(InterfaceCategoria interfaceCategoria)
        {
            _interfaceCategoria = interfaceCategoria;
        }

        public Task AdicionarCategoria(Categoria categoria)
        {
            var valido = _interfaceCategoria.valida

            throw new NotImplementedException();
        }

        public Task AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
