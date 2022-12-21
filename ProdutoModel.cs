using PagedList;
using System.ComponentModel.DataAnnotations;
namespace Mvc_Consultas.Models
{
    public class ProdutoModel
    {
        public int? Pagina { get; set; }
        [Display(Name = "Produto")]
        public string Nome { get; set; }
        public decimal? Preco { get; set; }
        public IPagedList<Produto> ProcuraResultados { get; set; }
        public string BotaoProcurar { get; set; }
    }
}
