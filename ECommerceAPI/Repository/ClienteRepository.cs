using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new Exception(); 
            }

            _context.SaveChanges();
        }

        public Cliente BuscarPOEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPOId(int id)
        {
            
                return _context.Clientes.FirstOrDefault(p => p.IdCliente == id);
            
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if(clienteEncontrado == null)
            {
                throw new Exception();
            }

            _context.Clientes.Remove(clienteEncontrado);
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
