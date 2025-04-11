using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repository
{
    public class ItemPedidoRepository: IItemPedidoRepository
    {
        private readonly EcommerceContext _context;
        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public ItemPedido BuscarPOId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itempedido)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
