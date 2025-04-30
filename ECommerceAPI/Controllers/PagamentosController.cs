using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {

        private IPagamentosRepository _pagamentoRepository;

        public PagamentosController(IPagamentosRepository pagamentoRepository)
        {

            _pagamentoRepository = pagamentoRepository;
        }


        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPagamentoDTO item)
        {
            _pagamentoRepository.Cadastrar(item);

            return Created();
        }


        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {

            Pagamento pagamento = _pagamentoRepository.BuscarPOId(id);

            if (pagamento == null)
            {
                return NotFound();
            }
            return Ok(pagamento);
        }
        [HttpPut("{id}")]

        public IActionResult Editar(int id, Pagamento pagamento)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pagamento);
                return Ok(pagamento);
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
                _pagamentoRepository.Deletar(id);

                return NoContent();
            }
          
            catch (Exception ex)
            {
                return NotFound("Pagamento nao encontrado");
            }
        }
    }
}
