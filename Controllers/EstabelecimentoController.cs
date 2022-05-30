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
    public class EstabelecimentoController : Controller
    {
        private HotelDBEntities db = new HotelDBEntities();

        public ActionResult Index()
        {
            var estabelecimentos = db.Estabelecimento.Include("Cidade").Include("Categoria").ToList();
            return View(estabelecimentos);
        }
        public ActionResult Inserir()
        {
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome");
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Estabelecimento.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", estabelecimento.IdCidade);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao", estabelecimento.IdCategoria);
            return View(estabelecimento);
        }
        public ActionResult Alterar(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", estabelecimento.IdCidade);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao", estabelecimento.IdCategoria);
            return View(estabelecimento);
        }

        [HttpPost]
        public ActionResult Alterar(Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", estabelecimento.IdCidade);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao", estabelecimento.IdCategoria);
            return View(estabelecimento);
        }

        public ActionResult Excluir(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", estabelecimento.IdCidade);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao", estabelecimento.IdCategoria);
            return View(estabelecimento);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusão(int id)
        {
          try
          {
             Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
             db.Estabelecimento.Remove(estabelecimento);
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