using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();

        Pedido BuscarPOId(int id);

        void Cadastrar(cadastrarPedido pedido);

        void Atualizar(int id, Pedido Pedido);

        void Deletar(int id);

    }
}
