using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private IClienteRepository _clienteRepository;

        private PasswordService _passwordService = new PasswordService();

        public ClienteController(IClienteRepository clienteRepository)
        {

            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Authorize]
        
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarClienteDTO item)
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
        }
        [HttpGet("/buscar/{nome}")]

        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var cliente = _clienteRepository.BuscarPOEmailSenha(login.Email, login.Senha);
            if (cliente == null)
            {
                return Unauthorized("Email ou Senha invalido");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(cliente.Email);


            return Ok(token);
        }
    }

    
}
