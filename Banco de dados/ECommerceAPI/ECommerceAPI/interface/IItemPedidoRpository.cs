using EcommerceAPI.Models;

namespace EcommerceAPI. interfaces
{
    public interface IItemPedidoRepository
    {
        List<ItemPedido> ListarTodos();

       ItemPedido BuscarPOId(int id);

        void Cadastrar(ItemPedido itempedido);

        void Atualizar(int id,ItemPedido itemPedido);

        void Deletar(int id);
    }
}
