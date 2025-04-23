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

        public void Atualizar(int id, Cliente clienteNovo)
        {
            Cliente clienteEncontrado = _context.Clientes.FirstOrDefault( p => p.IdCliente == id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado"); 
            }
            clienteEncontrado.NomeCompleto=clienteNovo.NomeCompleto;
            clienteEncontrado.Email = clienteNovo.Email;
            clienteEncontrado.Endereco = clienteNovo.Endereco;
            clienteEncontrado.Telefone=clienteNovo.Telefone;
            clienteEncontrado.Senha=clienteNovo.Senha;
            clienteEncontrado.DataCdastro=clienteNovo.DataCdastro;

            _context.SaveChanges();
        }

        public Cliente? BuscarPOEmailSenha(string email, string senha)
        {
            //Encontrar o cliente que possui o e mail e senha fornecido
            var clienteEncontrado=_context.Clientes.FirstOrDefault(p => p.Email == email && p.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente? BuscarPOId(int id)
        {
            //qualquer metodo que vai me trazer apenas 1 cli3nte (FirstOrDefault)
                return _context.Clientes.FirstOrDefault(p => p.IdCliente == id);
            
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            //FirstOrDefault pesquisa por qualquer campo
            // Find(id) sempre pesquisa pelo id ou chave primaria
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if(clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado");
            }

            _context.Clientes.Remove(clienteEncontrado);
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
           return _context.Clientes.ToList();
        }
    }
}
