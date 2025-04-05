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

create table cliente (
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

--DML - criar alterar ou apagar dados
--DML - data manipulation language
--DQL - ver os dados
--DQL - data query language
