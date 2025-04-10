using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IProdutoRepository _produtoRepository;
        //Metodo construtor
        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(_context);
        }
        //GET
        [HttpGet]
        public IActionResult ListarProdutos() 
        { 
            return Ok(_produtoRepository.ListarTodos());
        }
            
    }
}
