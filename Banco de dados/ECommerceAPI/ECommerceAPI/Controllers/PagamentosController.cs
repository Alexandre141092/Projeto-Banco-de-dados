using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPagamentosRepository _pagamentoRepository;
    
        public PagamentosController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new PagamentoRepository(_context);
        }

       

    }
}
