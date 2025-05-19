namespace EcommerceAPI.DTO
{
    public class CadastrarPedidoDTO
    {
        public int IdPedido { get; set; }

        public DateOnly DataPedido { get; set; }

        public string Status { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

    }
}
