
--DML - inserir dados, aletrar e apagar dados

-- Insert into - inserir dados
USE ECommerce

INSERT INTO Produto (Nome, Descricao, Preco, EstoqueDisponivel, Categoria, Imagem)
VALUES
('Mouse', 'Mouse Logitech', 99.90, 50, 'Informatica', ''),
('Teclado', 'Teclado Dell', 209.50, 100, 'Informatica', '')


INSERT INTO Cliente (NomeCompleto, Email, Telefone, Endereco, DataCdastro, Senha)
VALUES
('Vinicio Santos', 'Vinicio@senai.br', '(11) 999944444', 'Rua niteroi 180, - sao paulo', '05/04/2022','13456'),
('Saulo santos', 'SAulo@senai.br', '(11) 25421104', 'Rua niteroi 250, - sao paulo', '05/05/2018', '141098')

INSERT INTO Pedido (IdCliente, DataPedido, Status, ValorTotal)
VALUES
(1,'06/05/2023', 'Processando', 3200.99),
(2,'10/05/2023', 'concluido', 450.99)

INSERT INTO Pagamento (IdPedido, FormaPagamento, StatusPagamento, DataPagamnento)
VALUES
(1,'Cartao de credito', 'Aprovado', '08/05/2023 12:00:00'),
(2, 'Boleto', 'Aprovado', '18/05/2023 16:30:00')

INSERT INTO ItemPedido (IdPedido, IdProduto, Quantidade)
VALUES
(2,1,2),
(2,2,1),
(3,1,1) 

--DELETE FROM Cliente WHERE NomeCompleto = 'Vinicio Santos';

--DQL - comandos para visualizar os dados

--Select * (ver tudo) ou "from" para ver o que for selecionado

SELECT * FROM Cliente;
