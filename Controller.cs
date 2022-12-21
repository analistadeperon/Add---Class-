using System.Linq;
using System.Web.Mvc;
using Mvc_Consultas.Models;
using PagedList;
namespace Mvc_Consultas.Controllers
{
    public class ProdutoController : Controller
    {
        const int RegistrosPorPagina = 5;
        //
        // GET: /Produto/
        public ActionResult Index(ProdutoModel model)
        {
            if (!string.IsNullOrEmpty(model.BotaoProcurar) || model.Pagina.HasValue)
            {
                var entities = new CadastroEntities();
                var results = entities.Produtos
                              .Where(p => (p.Nome.StartsWith(model.Nome) || model.Nome == null) && (p.Preco > model.Preco || model.Preco == null))
                              .OrderBy(p => p.Nome);
                var pageIndex = model.Pagina ?? 1;
                model.ProcuraResultados = results.ToPagedList(pageIndex, RegistrosPorPagina );
            }
            return View(model);
        }
   }
}
