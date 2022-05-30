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
    public class CidadeController : Controller
    {
        private HotelDBEntities db = new HotelDBEntities();
        public ActionResult Index()
        {
            var cidades = db.Cidade.ToList();
            return View(cidades);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Alterar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        public ActionResult Excluir(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusão(int id)
        {
            try
            {
              Cidade cidade = db.Cidade.Find(id);
                db.Cidade.Remove(cidade);
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