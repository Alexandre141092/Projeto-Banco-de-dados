using EcommerceAPI.Models;

namespace EcommerceAPI.interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();

        Cliente BuscarPOId(int id);
        Cliente BuscarPOEmailSenha(string email, string senha);

        void Cadastrar(Cliente cliente);    

        void Atualizar(int id, Cliente cliente);

        void Deletar(int id);   

    }
}
