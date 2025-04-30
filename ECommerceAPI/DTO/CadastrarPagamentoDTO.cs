namespace EcommerceAPI.DTO
{
    public class CadastrarPagamentoDTO
    {
        public int IdPedido { get; set; }

        public string FormaPagamento { get; set; } = null!;

        public string StatusPagamento { get; set; } = null!;

        public DateOnly DataPagamnento { get; set; }
    }
}
