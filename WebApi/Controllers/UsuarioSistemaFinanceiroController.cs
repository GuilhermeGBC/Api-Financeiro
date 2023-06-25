using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.IUsuarioSistemaFinanceira;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _usuarioSistemaFinanceiroService;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
                                                  IUsuarioSistemaFinanceiroService usuarioSistemaFinanceiroService)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroService = usuarioSistemaFinanceiroService;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroService.CadastrarUsuarioSistema(
                    new UsuarioSistemaFinanceiro
                    {
                        IdSistema = idSistema,
                        EmailUsuario = emailUsuario,
                        Administrador = false,
                        SistemaAtual = true
                    });
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuario = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);
                await _interfaceUsuarioSistemaFinanceiro.Delete(usuario);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
