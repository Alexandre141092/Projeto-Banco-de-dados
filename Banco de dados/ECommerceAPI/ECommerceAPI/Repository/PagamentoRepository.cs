using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repository
{
    public class PagamentoRepository: IPagamentosRepository
    {
        private readonly EcommerceContext _context;

        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pagamento pagamento)
        {
            throw new NotImplementedException();
        }

        public Pagamento BuscarPOId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pagamento pagamento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pagamento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
