using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrganicosEmCasa.Models;

namespace OrganicosEmCasa.Controllers
{
    public class ProdutoVendasController : Controller
    {
        private IOrganicosEmCasaDBContext db;
        public ProdutoVendasController()
        {
            this.db = new OrganicosEmCasaDBContext();
        }

        public ProdutoVendasController(IOrganicosEmCasaDBContext db)
        {
            this.db = db;
        }


        public ActionResult Index()
        {
            return View(db.ProdutoVendas.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVenda produtoVenda = db.ProdutoVendas.Find(id);
            if (produtoVenda == null)
            {
                return HttpNotFound();
            }
            return View(produtoVenda);
        }

       
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDVenda,Quantidade,Preco")] ProdutoVenda produtoVenda)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoVendas.Add(produtoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtoVenda);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVenda produtoVenda = db.ProdutoVendas.Find(id);
            if (produtoVenda == null)
            {
                return HttpNotFound();
            }
            return View(produtoVenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDVenda,Quantidade,Preco")] ProdutoVenda produtoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtoVenda);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVenda produtoVenda = db.ProdutoVendas.Find(id);
            if (produtoVenda == null)
            {
                return HttpNotFound();
            }
            return View(produtoVenda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoVenda produtoVenda = db.ProdutoVendas.Find(id);
            db.ProdutoVendas.Remove(produtoVenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
