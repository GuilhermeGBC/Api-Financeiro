using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(InterfaceCategoria interfaceCategoria, ICategoriaService categoriaService)
        {
            _interfaceCategoria = interfaceCategoria;
            _categoriaService = categoriaService;
        }

        [HttpGet("api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }

        [HttpPut("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _categoriaService.AdicionarCategoria(categoria);
            return categoria;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _categoriaService.AtualizarCategoria(categoria);
            return categoria;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _interfaceCategoria.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _interfaceCategoria.GetEntityById(id);
                await _interfaceCategoria.Delete(categoria);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
