using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context; 
        }

        public void Atualizar(int id, Pedido Pedido)
        {
            Pedido PediddoEcontrado = _context.Pedidos.Find(id);
            {
                if (PediddoEcontrado == null)
                {
                    throw new Exception();
                }

                _context.SaveChanges();

            }

          

           
        }

        public Pedido BuscarPOId(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
        }

        public void Cadastrar(CadastrarPedidoDTO pedido)
        {
            Pedido CadastrarPedido = new Pedido
            {
                IdPedido = pedido.IdPedido,
                DataPedido = pedido.DataPedido,
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal,
                IdCliente = pedido.IdCliente,

            };

            _context.Pedidos.Add(CadastrarPedido);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);
            {
                if(pedidoEncontrado == null)
                {
                    throw new ArgumentNullException("Pedido não encontrado");
                }

                _context.Pedidos.Remove(pedidoEncontrado);
                _context.SaveChanges();
            }
        }

        public List<Pedido> ListarTodos()
        {
            return  _context.Pedidos.ToList();
        }
    }
}
