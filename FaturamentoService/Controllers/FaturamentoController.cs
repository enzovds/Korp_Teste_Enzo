using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FaturamentoService.Data;
using FaturamentoService.Models;

namespace FaturamentoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public FaturamentoController(AppDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        // GET: api/faturamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscal>>> ListarNotas()
        {
            // Uso de LINQ para listar todas as notas fiscais
            return await _context.NotasFiscais.ToListAsync();
        }

        // POST: api/faturamento
        [HttpPost]
        public async Task<ActionResult<NotaFiscal>> EmitirNota(NotaFiscal nota)
        {
            nota.Status = "Aberta";
            
            _context.NotasFiscais.Add(nota);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListarNotas), new { id = nota.Id }, nota);
        }

        // PUT: api/faturamento/{id}/fechar
        [HttpPut("{id}/fechar")]
        public async Task<IActionResult> FecharNota(int id)
        {
            // Uso de LINQ para encontrar a nota fiscal pelo ID
            var nota = await _context.NotasFiscais.FirstOrDefaultAsync(n => n.Id == id);

            if (nota == null)
                return NotFound(new { mensagem = "Nota fiscal não encontrada." });

            if (nota.Status == "Fechada")
                 return BadRequest(new { mensagem = "Esta nota fiscal já está fechada." });

            // Comunicação com o microsserviço de Estoque (dar baixa automática)
            string estoqueUrl = $"http://localhost:5211/api/Produtos/{nota.CodigoProduto}/dar-baixa";
            
            var content = new StringContent(nota.Quantidade.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(estoqueUrl, content);

            if (!response.IsSuccessStatusCode)
                return BadRequest(new { mensagem = "Erro ao dar baixa no estoque. Verifique o saldo ou o código do produto." });

            nota.Status = "Fechada";
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Nota fiscal fechada e estoque atualizado com sucesso!" });
        }
    }
}