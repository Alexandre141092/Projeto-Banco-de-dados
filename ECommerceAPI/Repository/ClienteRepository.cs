using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Services;
using EcommerceAPI.ViewModels;

namespace EcommerceAPI.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        public List<ListarClienteViewModels> ListarTodos()
        {
            return _context.Clientes
                .Select(c => new ListarClienteViewModels
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco
                })
                .ToList();
        }
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

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            //Where - ele traz todos que atendem a condicao
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto==nome).ToList();

            return listaClientes;
        }

        public Cliente? BuscarPOEmailSenha(string email, string senha)
        {
            //Encontrar o cliente que possui o e mail e senha fornecido
            //procuro pelo e mail
            var clienteEncontrado = _context.Clientes.FirstOrDefault(p => p.Email == email && p.Senha == senha);

            //Caso nao econtro, retorno null
            if (clienteEncontrado == null)
            {
                return null;
            }

            var passwordService = new PasswordService();

            //
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);

            if (resultado == true) return clienteEncontrado;

            return null;

        }



           

        public Cliente? BuscarPOId(int id)
        {
            //qualquer metodo que vai me trazer apenas 1 cli3nte (FirstOrDefault)
                return _context.Clientes.FirstOrDefault(p => p.IdCliente == id);
            
        }

        public void Cadastrar(CadastrarClienteDTO cliente)
        {
            var passwordservice = new PasswordService();


            Cliente cadastroCliente = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Senha = cliente.Senha,
                DataCdastro = cliente.DataCdastro
            };
            cliente.Senha = passwordservice.HashPassword(cadastroCliente);

            _context.Clientes.Add(cadastroCliente);
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

       

            
        
    }
}
