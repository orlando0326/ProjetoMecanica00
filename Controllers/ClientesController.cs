using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        //GET api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.Clientes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CriarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente Criado com sucesso!");


        }
        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarCliente(int id, Cliente cliente)
        {
            var clienteAtual = await _context.Clientes.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }
            clienteAtual.CPF = cliente.CPF;
            clienteAtual.telefone = cliente.telefone;
            clienteAtual.Name = cliente.Name;
            clienteAtual.Email = cliente.Email;

            await _context.SaveChangesAsync();

            return Ok("clienteAtual");
        }
        [HttpDelete]
        public async Task<ActionResult> DeletarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente deletado com sucesso!");

        }
    }
}

