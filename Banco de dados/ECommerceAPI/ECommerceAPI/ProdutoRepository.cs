using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EcommerceAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        //Metodos que acessam os bancos de dados 

        //Injetar o context
        //injecao de independencia
      
        private readonly EcommerceContext _context;

        //Metodo construtor
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            //Encontro produto que desejo
            Produto produtoEncontrado = _context.Produtos.Find(id);
            //caso nao encontro o produto, lanco o erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }


            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            _context.SaveChanges();
        }

        public Produto BuscarPOId(int id)
            //ToList() - Pegar varios
            //FirstorDefault - Traz o primeriro que encontar ou, null
            //Expressao lambda
            //_contexte.Produtos - Acesse a tabela produto do contexto
            //FirstorDefault - Pegue o promeiro que encontrar p => p.IdProdutos ==id
            //Para cada produto p, me retorne aquele que tem o IdProduto igualao id
        {
            return _context.Produtos.FirstOrDefault(p => p.IdProduto==id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1- Econtrar o que quero excluir 
            //Find - Procura pela chave primaria
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                throw new Exception();

            }

            // Caso eu encontre o produto, removo ele 
            _context.Produtos.Remove(produtoEncontrado);

            //Salvo as alteracoes
            _context.SaveChanges();
        }


        public List<Produto> ListarTodos()
        {
           return _context.Produtos.ToList();
        }
    }
}
