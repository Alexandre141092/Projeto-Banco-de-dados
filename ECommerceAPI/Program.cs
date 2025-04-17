using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//O .NETvaicriar os objetos (injecao de independencia)
//AddTransient - OC# criar uma estancia nova, toda vez em que o metodo e chamado
//AddScoped - OC# cria uma instancia nova,  toda vez que criar um controller
//AddSingleton - 
builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentosRepository, PagamentoRepository>();


var app = builder.Build();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
