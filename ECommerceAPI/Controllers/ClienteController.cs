using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private IClienteRepository _clienteRepository;
      
        public ClienteController(ClienteRepository clienteRepository)
        {
            
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListarProdutos(Cliente cliente)
        {
            return Ok(_clienteRepository.ListarTodos());
        }

    }
}
