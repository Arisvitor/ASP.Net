using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Hotel.Models;

namespace Hotel.Controllers
{
   public class HomeController : Controller
    {
       private HotelDBEntities db = new HotelDBEntities();

       public ActionResult Index()
       {
           ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Nome");
           ViewBag.Categoria = new SelectList(db.Categoria, "IdCategoria", "Descricao");

           return View();
       }

       public ActionResult Pesquisar(Pesquisa pesquisa)
       {
            var estabelecimentos = from r in db.Estabelecimento
                                   where r.IdCidade == pesquisa.IdCidade && r.IdCategoria == pesquisa.IdCategoria
                                   select new ResultadoPesquisa
                                   {
                                       NomeComercial = r.NomeComercial,
                                       RazaoSocial = r.RazaoSocial,
                                       Endereco = r.Endereco,
                                       Telefone = r.Telefone,
                                       Site = r.Site
                                   }; 
          return Json(estabelecimentos, JsonRequestBehavior.AllowGet);
        }
    }
}