using EcommerceAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Services
{
    public class PasswordService
    {
        //PasswordHasher - PBKDF2
        private readonly PasswordHasher<Cliente> _hasher = new(); 



        //1- Gerar um Hash
        public string HashPassword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }
        //2- Verificar o Hash
        public bool VerificarSenha(Cliente cliente, string senhainformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhainformada);

            return resultado == PasswordVerificationResult.Success; 
        }
    }
}
