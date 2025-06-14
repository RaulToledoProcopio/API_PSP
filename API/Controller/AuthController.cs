﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using API.DTO;
using API.Model;
using API.Service;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MongoDBService _mongoDbService;

        public AuthController(MongoDBService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }
        
        [HttpPost("register")]
        public ActionResult Register([FromBody] User user)
        {
            // Verificar si el usuario ya existe
            var existingUser = _mongoDbService.GetUserByUsername(user.Username);
            if (existingUser != null)
                return BadRequest("El usuario ya existe");

            // Verificar si el email ya está registrado
            var existingEmail = _mongoDbService.GetUserByEmail(user.Email);
            if (existingEmail != null)
                return BadRequest("El email ya está registrado");

            // Encriptar la contraseña antes de guardarla
            user.PasswordHash = HashPassword(user.PasswordHash);
    
            // Guardar el usuario en la base de datos
            _mongoDbService.RegisterUser(user);
            return Ok("Usuario registrado");
        }

        
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto request)
        {
            var dbUser = _mongoDbService.GetUserByUsername(request.Username);
            
            if (dbUser == null || dbUser.PasswordHash != HashPassword(request.PasswordHash))
                return Unauthorized("Credenciales incorrectas");

            return Ok("Login correcto");
        }


        // Método para hacer hash a la contraseña
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}