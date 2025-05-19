using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoControllers : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoControllers(IPedidoRepository pedidoRepository)
        {

            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarPedido()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDTO item)
        {
            _pedidoRepository.Cadastrar(item);

            return Created();
        }

        //Buscar o produto por id
        // /api/produtos
        // /api/produtos/1
        [HttpGet("{id}")]
        public ActionResult ListarPorId(int id)
        {
            Pedido pedido = _pedidoRepository.BuscarPOId(id);

            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }
        [HttpPut("{id}")]

        public IActionResult Editar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);
                return Ok(pedido);
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
                _pedidoRepository.Deletar(id);

                return NoContent();
            }
            // Caso de erro
            catch (Exception ex)
            {
                return NotFound("Pedido nao encontrado");
            }

        }

    }
}
