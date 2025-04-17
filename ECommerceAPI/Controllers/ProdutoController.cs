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
    public class ProdutoController : ControllerBase
    {

        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {

            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPedido(Produto item)
        {
            _produtoRepository.Cadastrar(item);

            return Created();
        }

        //Buscar o produto por id
        // /api/produtos
        // /api/produtos/1
        [HttpGet("{id}")]
        public ActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPOId(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
        [HttpPut("{id}")]

        public IActionResult Editar(int id, Produto prod)
        {
            try
            {
                _produtoRepository.Atualizar(id, prod);
                return Ok(prod);
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
                _produtoRepository.Deletar(id);

                return NoContent();
            }
           // Caso de erro
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado");
            }


        }
    }
}
