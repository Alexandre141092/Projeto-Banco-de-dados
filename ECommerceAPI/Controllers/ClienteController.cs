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
        [HttpPost]
        public IActionResult CadastrarPedido(Cliente item)
        {
            _clienteRepository.Cadastrar(item);

            return Created();
        }


        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {

            Cliente cliente = _clienteRepository.BuscarPOId(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpPut("{id}")]

        public IActionResult Editar(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);

                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado");
            }
          
        }// /api/vini@senai/
        [HttpGet("{email}/{senha}")]
        public IActionResult Login(string email, string senha)
        {
            var cliente = _clienteRepository.BuscarPOEmailSenha(email, senha);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }   

    }
}
