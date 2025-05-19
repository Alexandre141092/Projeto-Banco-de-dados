using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();

        Pedido BuscarPOId(int id);

        void Cadastrar(CadastrarPedidoDTO pedido);

        void Atualizar(int id, Pedido Pedido);

        void Deletar(int id);

    }
}
