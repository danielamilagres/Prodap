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
    public class ProdutoesController : Controller
    {
        private IOrganicosEmCasaDBContext db;
        public ProdutoesController()
        {
            this.db = new OrganicosEmCasaDBContext();
        }

        public ProdutoesController(IOrganicosEmCasaDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index(int? Categoria)
        {
            if (Categoria != null)
                return View(db.Produtos.SqlQuery("Select * from Produtoes where Categoria_Id =" + Categoria).ToList());
            else
                return View(db.Produtos.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,URLImagem,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,URLImagem,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }


        public ActionResult MenuCategoria()
        {
            return PartialView(db.Categorias.ToList());
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
