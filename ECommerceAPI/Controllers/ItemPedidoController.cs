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
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoRepository _itempedidoRepository;

        public ItemPedidoController(ItemPedidoRepository itemPedidoRepository)
        {
            
            _itempedidoRepository = itemPedidoRepository;
        }


        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_itempedidoRepository.ListarTodos());
        }
    }
}
