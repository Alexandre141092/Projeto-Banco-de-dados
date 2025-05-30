﻿using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public int IdPedido { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string StatusPagamento { get; set; } = null!;

    public DateOnly DataPagamnento { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; } = null!;
    //padrao do frameworks <nome tabela>ID
}
