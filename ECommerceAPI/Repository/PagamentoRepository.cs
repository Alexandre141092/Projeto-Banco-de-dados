using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public void Cadastrar(CadastrarPagamentoDTO pagamento)
        {
            Pagamento cadastrarPagamento = new Pagamento
            {
                IdPedido = pagamento.IdPedido,
                FormaPagamento = pagamento.FormaPagamento,
                StatusPagamento = pagamento.StatusPagamento,
                DataPagamnento = pagamento.DataPagamnento

            };

            _context.Pagamentos.Add(cadastrarPagamento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new ArgumentNullException("Pagamento nao encontrado");
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos
                .Include(p => p.IdPedidoNavigation)
                .ToList();
        }
    }
}
