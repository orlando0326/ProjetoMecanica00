using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        // POST api/veiculos
        [HttpPost]
        public async Task<ActionResult> CriarVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veículo criado com sucesso!");
        }

        // PUT api/veiculos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarVeiculo(int id, Veiculo veiculo)
        {
            var veiculoAtual = await _context.Veiculos.FindAsync(id);
            if (veiculoAtual == null)
            {
                return NotFound();
            }

            veiculoAtual.Placa = veiculo.Placa;
            veiculoAtual.Cliente = veiculo.Cliente;
            veiculoAtual.cor = veiculo.cor;
            veiculoAtual.Modelo = veiculo.Modelo;

            await _context.SaveChangesAsync();

            return Ok("Veículo alterado com sucesso!");
        }

        // DELETE api/veiculos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo deletado com sucesso!");
        }
    }
}