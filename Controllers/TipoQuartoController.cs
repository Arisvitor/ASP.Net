using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI;

namespace Hotel.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class TipoQuartoController : Controller
    {
        private HotelDBEntities db = new HotelDBEntities();
        public ActionResult Index()
        {
            var tipoQuartos = db.TipoQuarto.ToList();
            return View(tipoQuartos);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(TipoQuarto tipoQuarto)
        {
            if (ModelState.IsValid)
            {
                db.TipoQuarto.Add(tipoQuarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            TipoQuarto tipoQuarto = db.TipoQuarto.Find(id);
            return View(tipoQuarto);
        }

        [HttpPost]
        public ActionResult Alterar(TipoQuarto tipoQuarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoQuarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoQuarto);
        }

        public ActionResult Excluir(int id)
        {
            TipoQuarto tipoQuarto = db.TipoQuarto.Find(id);
            return View(tipoQuarto);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusão(int id)
        {
          try
          {
            TipoQuarto tipoQuarto = db.TipoQuarto.Find(id);
            db.TipoQuarto.Remove(tipoQuarto);
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
    }
}