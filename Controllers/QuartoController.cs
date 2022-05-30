using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Hotel.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class QuartoController : Controller
    {
        private HotelDBEntities db = new HotelDBEntities();
        public ActionResult Index()
        {
            var quartos = db.Quarto.Include("Estabelecimento").Include("TipoQuarto").ToList();
            return View(quartos);
        }
        public ActionResult Inserir()
        {
            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "NomeComercial");
            ViewBag.IdTipoQuarto = new SelectList(db.TipoQuarto, "IdTipoQuarto", "Descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Quarto.Add(quarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "NomeComercial", quarto.IdEstabelecimento);
            ViewBag.IdTipoQuarto = new SelectList(db.TipoQuarto, "IdTipoQuarto", "Descricao", quarto.IdTipoQuarto);
            return View();
        }
        public ActionResult Alterar(int id)
        {

            Quarto quarto = db.Quarto.Find(id);
            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "NomeComercial", quarto.IdEstabelecimento);
            ViewBag.IdTipoQuarto = new SelectList(db.TipoQuarto, "IdTipoQuarto", "Descricao", quarto.IdEstabelecimento);
            return View(quarto);
        }

        [HttpPost]
        public ActionResult Alterar(Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "NomeComercial", quarto.IdEstabelecimento);
            ViewBag.IdTipoQuarto = new SelectList(db.TipoQuarto, "IdTipoQuarto", "Descricao", quarto.IdEstabelecimento);
            return View(quarto);
        }

        public ActionResult Excluir(int id)
        {
            Quarto quarto = db.Quarto.Find(id);
            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "NomeComercial", quarto.IdEstabelecimento);
            ViewBag.IdTipoQuarto = new SelectList(db.TipoQuarto, "IdTipoQuarto", "Descricao", quarto.IdEstabelecimento);
            return View(quarto);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusão(int id)
        {
          try
          {
            Quarto quarto = db.Quarto.Find(id);
            db.Quarto.Remove(quarto);
            db.SaveChanges();
            return RedirectToAction("Index");
          }
          catch
          {
            return RedirectToAction("ErroExcluir");
          }
        }

        public ActionResult ErroExcluir()
        {
            return View();
        }

        public ActionResult VerificaSeNumeroQuartoNaoExiste(int IdEstabelecimento, int NumeroQuarto)

        {
            var quarto = db.Quarto.Where(f => f.NumeroQuarto == NumeroQuarto).FirstOrDefault();
            if (quarto != null)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}