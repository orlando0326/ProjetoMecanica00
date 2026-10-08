using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetVeiculos()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        // POST api/veiculos
        [HttpPost]
        public async Task<ActionResult> CriarAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return Ok("Veículo criado com sucesso!");
        }

        // PUT api/veiculos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarAgendamento(int id, Agendamento agendamento)
        {
            var AgendamentoAtual = await _context.Agendamentos.FindAsync(id);
            if (AgendamentoAtual == null)
            {
                return NotFound();
            }

            AgendamentoAtual.Data= agendamento.Data;
            AgendamentoAtual.Servico= agendamento.Servico;

            await _context.SaveChangesAsync();

            return Ok("Agendamento alterado com sucesso!");
        }

        // DELETE api/veiculos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento== null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento deletado com sucesso!");
        }
    }
} 










