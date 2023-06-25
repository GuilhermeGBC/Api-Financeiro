using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaFinanceirosController : ControllerBase
    {
        private readonly ISistemaFinanceiroService _sistemaFinanceiroService;
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceirosController(ISistemaFinanceiroService sistemaFinanceiroService,
                                            InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _sistemaFinanceiroService = sistemaFinanceiroService;
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }

        [HttpGet("/api/ListarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarSistemasUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListarSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroService.AdicionarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroService.AtualizarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemFinanceiro(int id)
        {
            return await _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistema = await _interfaceSistemaFinanceiro.GetEntityById(id);
                await _interfaceSistemaFinanceiro.Delete(sistema);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
