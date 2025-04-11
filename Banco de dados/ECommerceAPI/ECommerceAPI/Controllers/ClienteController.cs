using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IClienteRepository _clienteRepository;
      
        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(_context);
        }

       

    }
}
