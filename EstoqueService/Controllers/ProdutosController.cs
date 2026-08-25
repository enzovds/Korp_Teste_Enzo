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
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return Ok(produto); // Retorna Ok corrigindo o erro do Id
        }

        // PUT: api/produtos/{codigo}/dar-baixa
        [HttpPut("{codigo}/dar-baixa")]
        public async Task<IActionResult> DarBaixa(string codigo, [FromBody] int quantidade)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);
            
            if (produto == null) 
                return NotFound(new { mensagem = "Produto não encontrado." });
                
            if (produto.Saldo < quantidade) 
                return BadRequest(new { mensagem = "Saldo insuficiente no estoque." });

            produto.Saldo -= quantidade;
            await _context.SaveChangesAsync();
            
            return Ok(new { mensagem = "Baixa realizada com sucesso." });
        }

        // DELETE: api/produtos/{codigo}
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeletarProduto(string codigo)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);
            
            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Produto apagado com sucesso!" });
        }
    }
}