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
   NomeCompleto VARCHAR(150),
   Email VARCHAR(100),
   Telefone VARCHAR(20),
   Endereco VARCHAR(255),
   DataCdastro DATE,
   );

create table Pedido(
   IdPedido INT PRIMARY KEY IDENTITY,
   DataPedido DATE,
   Status VARCHAR(20),
   ValorTotal DECIMAL(18, 6),
   IdCliente INT FOREIGN KEY REFERENCES Cliente (IdCliente),
);

create table Pagamento(
   IdPagamento INT PRIMARY KEY IDENTITY,
   FormaPagamento VARCHAR(30),
   StatusPagamento VARCHAR(20),
   DataPagamnento DATE,
   IdPedido INT FOREIGN KEY REFERENCES Pedido (IdPedido),
);


create table Produto(
   IdProduto INT PRIMARY KEY IDENTITY,
   Nome VARCHAR(150),
   Descricao VARCHAR(100),
   Preco DECIMAL(18, 6),
   EstoqueDisponivel INT,
   Categoria VARCHAR(100),
   Imagem VARCHAR(255),
);


create table ItemPedido(
   IdItemPedido INT PRIMARY KEY IDENTITY,
   Quantidade INT,
   IdPedido INT FOREIGN KEY REFERENCES Pedido (IdPedido),
   IdProduto INT FOREIGN KEY REFERENCES Produto (IdProduto),
);

--alter table ItemPedido

/*
DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Cliente;
*/
--DML - criar alterar ou apagar dados
--DML - data manipulation language
--DQL - ver os dados
--DQL - data query language
