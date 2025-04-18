﻿using EcommerceAPI.Context;
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
    
        public PagamentosController(PagamentoRepository pagamentoRepository)
        {
           
            _pagamentoRepository = pagamentoRepository;
        }


        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult CadastrarPedido(Pagamento item)
        {
            _pagamentoRepository.Cadastrar(item);

            return Created();
        }

        //Buscar o produto por id
        // /api/produtos
        // /api/produtos/1
        [HttpGet("{id}")]
        public ActionResult ListarPorId(int id)
        {
            Produto produto = _pagamentoRepository.BuscarPOId(id);

            if (pagamento == null)
            {
                return NotFound();
            }
            return Ok(pagamento);
        }
        [HttpPut("{id}")]

        public IActionResult Editar(int id, Pagamento prod)
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
            // Caso de erro
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado");
            }
        }
}
