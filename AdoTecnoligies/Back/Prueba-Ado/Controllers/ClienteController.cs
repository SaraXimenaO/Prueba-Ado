using Application.Recaudos;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Prueba_Ado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : ControllerBase
    {
        private readonly IClientes _Cliente;

        public ClienteController(IClientes clientes)
        {
            _Cliente = clientes;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await _Cliente.GetClientes();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(Cliente cliente)
        {
            return await _Cliente.InsertCliente(cliente);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> Update(Cliente cliente)
        {
            return await _Cliente.UpdateCliente(cliente);
        }
    }
}