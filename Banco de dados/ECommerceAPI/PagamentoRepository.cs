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
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

          
            _context.SaveChanges();

        }
        

      
        public Pagamento BuscarPOId(int id)
        {
              return _context.Pagamentos.FirstOrDefault(p =>p.IdPagamento == id);
           
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.ToList();
        }
    }
}
