#1 - Adicionar interface (Itempedido)

#2 - Adicionar os métodos 
 métodos: List<Itempedido>ListarTudo();
Itempedido BuscarPor Id(int id);
void Cdastrar (Itempedido itempedido);
void Atualizar (int id, ItemPeddido itempedido);
void Deletar (int id);

#3 - Criar um Repository(IItempedido), na sequencia implementar na interface

#4 - injetar um contexto:
 private readonly IItempedidoRepository _itempedidoRepository 

public ProdutoController(IProdutoRepository produtoRepository)
{
    
    _produtoRepository = produtoRepository;
}
        
#5 - implementar os métodos cadastrar

#6 - configurar a injeção de independência

#7 - Criar um controller 
private IItemPedidoRepository _itempedidoRepository;

public ItemPedidoController(ItemPedidoRepository itemPedidoRepository)
{
    
    _itempedidoRepository = itemPedidoRepository;
}


[HttpGet]
public IActionResult ListarProdutos()
{
    return Ok(_itempedidoRepository.ListarTodos());
}

[httppost]
public IActionResult CadastrarPedido(Itempedido item)
{
   _itempedidoRepositoryCadastrar(item);
    return Ceated();
}

#8 - configurar Swagger (opcional)

