using EcommerceAPI.DTO;
using EcommerceAPI.Models;
using EcommerceAPI.ViewModels;

namespace EcommerceAPI.interfaces
{
    public interface IClienteRepository
    {
        List<ListarClienteViewModels> ListarTodos();

        Cliente BuscarPOId(int id);
        Cliente BuscarPOEmailSenha(string email, string senha);

        void Cadastrar(CadastrarClienteDTO cliente);    

        void Atualizar(int id, Cliente cliente);

        void Deletar(int id);   
        
        List<Cliente> BuscarClientePorNome(string nome);



    }
}
