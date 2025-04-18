﻿using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IItemPedidoRepository _itempedidoRepository;

        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itempedidoRepository = new ItemPedidoRepository(_context);
        }

       

    }
}
