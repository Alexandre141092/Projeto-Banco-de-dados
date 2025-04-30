using System.Text;
using EcommerceAPI.Context;
using EcommerceAPI.interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//O .NETvaicriar os objetos (injecao de independencia)
//AddTransient - OC# criar uma estancia nova, toda vez em que o metodo e chamado
//AddScoped - OC# cria uma instancia nova,  toda vez que criar um controller
//AddSingleton - 
builder.Services.AddDbContext<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentosRepository, PagamentoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", static options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "ecommerce",
        ValidAudience = "ecommerce",
        IssuerSigningKey = new SimmetricSecuritykey
        (Encoding.UTF8.GetBytes("minha-chave-secreta-senai"))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapControllers();

app.UseAuthentication();
app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
