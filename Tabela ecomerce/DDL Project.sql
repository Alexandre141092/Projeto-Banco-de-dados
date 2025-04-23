USE ECommerce;



-- Linguagem SQL
--SQL - Structured Query Language
--Linguagem de consulta estruturada
-- Banco de dados -> tabelas -> colunas

-- T - SQL(Microsoft), PL/SQL (oracle) - tem if else, funcoes

-- sql - comandos
-- DDL - Criar, altear ou apagar banco de dados e tabela
--DDL - data definition language
--Create
-- drop - apaga banco de dados ou tabela

create database ECommerce;



-- drop database ECommerce

-- singular, comando letra maiuscula

create table Cliente (
-- PRIMARY KEY - coluna que identifica os cliente
-- IDENTITY - Gerada automaticamente
   IdCliente INT PRIMARY KEY IDENTITY ,
   NomeCompleto VARCHAR(150) NOT NULL,
   Email VARCHAR(100)NOT NULL UNIQUE,
   Telefone VARCHAR(20),
   Endereco VARCHAR(255),
   Senha VARCHAR (255)NOT NULL,
   DataCdastro DATE
   );

create table Pedido(
   IdPedido INT PRIMARY KEY IDENTITY,
   DataPedido DATE NOT NULL,
   Status VARCHAR(20) NOT NULL,
   ValorTotal DECIMAL(18, 6),
   IdCliente INT FOREIGN KEY REFERENCES Cliente (IdCliente) NOT NULL
);

create table Pagamento(
   IdPagamento INT PRIMARY KEY IDENTITY,
   IdPedido INT FOREIGN KEY REFERENCES Pedido (IdPedido)NOT NULL,
   FormaPagamento VARCHAR(30)NOT NULL,
   StatusPagamento VARCHAR(20)NOT NULL,
   DataPagamnento DATE NOT NULL
);


create table Produto(
   IdProduto INT PRIMARY KEY IDENTITY,
   Nome VARCHAR(150) NOT NULL,
   Descricao VARCHAR(100),
   Preco DECIMAL(18, 6)NOT NULL,
   EstoqueDisponivel INT NOT NULL,
   Categoria VARCHAR(100) NOT NULL,
   Imagem VARCHAR(255)
);


create table ItemPedido(
   IdItemPedido INT PRIMARY KEY IDENTITY,
   IdPedido INT FOREIGN KEY REFERENCES Pedido (IdPedido) NOT NULL,
   IdProduto INT FOREIGN KEY REFERENCES Produto (IdProduto) NOT NULL,
   Quantidade INT NOT NULL
);

  --alter table Cliente ALTER COLUMN NomeCompleto VARCHAR (255) NOT NULL

/*
DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;
*/

--DML - criar alterar ou apagar dados
--DML - data manipulation language
--DQL - ver os dados
--DQL - data query language
