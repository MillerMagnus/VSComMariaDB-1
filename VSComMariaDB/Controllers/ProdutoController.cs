using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// Pegar a lista de todas as pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Produto>> GetListaAsync()
        {
            var _DbContext = new _DbContext();
            var vLista = await _DbContext.Produto.ToListAsync();

            return vLista;
        }

        /// <summary>
        /// Pegar os dados de uma Produto específica
        /// </summary>
        /// <param name="id">ID da Produto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Produto> GetProduto(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();

            //Selecionar a Produto pelo id
            /*var vProduto = _DbContext.Produto
                .Where(p => p.Id == id)
                .FirstOrDefault();*/

            var vProduto = await _DbContext.Produto.FindAsync(id);

            //retornar dos dados
            return vProduto;
        }

        [HttpPost]
        public async Task<Produto> Inserir(Produto produto)
        {
            var _DbContext = new _DbContext();

            await _DbContext.Produto.AddAsync(produto);
            await _DbContext.SaveChangesAsync();

            return produto;
        }

        [HttpPut]
        public async Task<Produto> Alterar(Produto produto)
        {
            var _DbContext = new _DbContext();

            _DbContext.Produto.Entry(produto).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();

            return produto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();
            //Localizar o registro a ser removido pelo id
            var vProduto = await _DbContext.Produto.FindAsync(id);
            //Remover o registro encontrado
            _DbContext.Produto.Remove(vProduto);
            //Salvar alterações
            await _DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
