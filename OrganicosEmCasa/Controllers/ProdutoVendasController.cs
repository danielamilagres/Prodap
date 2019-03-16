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
        private OrganicosEmCasaDBContext db = new OrganicosEmCasaDBContext();

        // GET: ProdutoVendas
        public ActionResult Index()
        {
            return View(db.ProdutoVendas.ToList());
        }

        // GET: ProdutoVendas/Details/5
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

        // GET: ProdutoVendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ProdutoVendas/Edit/5
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

        // POST: ProdutoVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ProdutoVendas/Delete/5
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

        // POST: ProdutoVendas/Delete/5
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
