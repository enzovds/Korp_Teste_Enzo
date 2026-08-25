using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstoqueService.Data;
using EstoqueService.Models;

namespace EstoqueService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutos()
        {
            // Uso de LINQ para buscar todos os produtos do banco
            return await _context.Produtos.ToListAsync();
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListarProdutos), new { codigo = produto.Codigo }, produto);
        }

        // PUT: api/produtos/{codigo}/dar-baixa
        [HttpPut("{codigo}/dar-baixa")]
        public async Task<IActionResult> DarBaixa(string codigo, [FromBody] int quantidade)
        {
            // Uso de LINQ para encontrar o produto pelo código
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            if (produto.Saldo < quantidade)
                return BadRequest(new { mensagem = "Saldo insuficiente em estoque." });

            produto.Saldo -= quantidade;
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Baixa realizada com sucesso!", novoSaldo = produto.Saldo });
        }
    }
}