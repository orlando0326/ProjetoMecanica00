using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMecanica.Models;
using ProjetoMecanica.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ProjetoMecanicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(
                u => u.usuario == usuario.usuario &&
                     u.senha == usuario.senha
            );

            if (user == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            return Ok(user);
        }
    }
}