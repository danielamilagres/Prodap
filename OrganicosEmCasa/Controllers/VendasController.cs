﻿using System;
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
    public class VendasController : Controller
    {
        private OrganicosEmCasaDBContext db = new OrganicosEmCasaDBContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ConfirmarCompra(int VendaID)
        {
            //new List<Venda>(db.Vendas.Find(VendaID))
            return View();
        }


        public ActionResult FinalizarCompra(int ClienteID)
        {
            List<Carrinho> carrinho = (List<Carrinho>)Session["carrinho"];
            if (carrinho != null)
            {
                /*
                Venda venda = new Venda();

                //Preencher dados de Cliente
                Cliente clienteBanco = db.Clientes.Find(ClienteID);
                if (clienteBanco != null)
                {
                    string sqlVenda = "Insert into Vendas (Cliente_ID, IdSessao) values ( " + ClienteID + ", 0 )";
                    int idVenda = db.Database.ExecuteSqlCommand(sqlVenda);

                    foreach (var item in carrinho[0].ListaDeItens)
                    {
                        string sqlProdutoVenda = "insert into ProdutoVendas (IdVenda, Quantidade, Preco, Produto_ID, Venda_ID) values ("
                            + idVenda + ", " + item.Quantidade + ", " + item.Produto.Preco.ToString("#.00").Replace(",",".") + "," + item.Produto.ID + "," + idVenda + ")";
                        db.Database.ExecuteSqlCommand(sqlProdutoVenda);
                    }
                    db.SaveChanges();

                }

                Cliente clienteVenda = new Cliente { ID = clienteBanco.ID, CEP = clienteBanco.CEP, Cidade = clienteBanco.Cidade, CPF = clienteBanco.CPF, Endereco = clienteBanco.Endereco, Nome = clienteBanco.Nome, Telefone = clienteBanco.Telefone, UF = clienteBanco.UF };


                venda.Cliente = clienteVenda;
                */

                var venda = db.Vendas.Include(c => c.Cliente).First();
                var cliente = db.Clientes.Find(ClienteID);
                venda.Cliente = cliente;
                db.Vendas.Add(venda);
                db.SaveChanges();
                foreach (var item in carrinho[0].ListaDeItens)
                {
                    string sqlProdutoVenda = "insert into ProdutoVendas (IdVenda, Quantidade, Preco, Produto_ID, Venda_ID) values ("
                            + venda.ID + ", " + item.Quantidade + ", " + item.Produto.Preco.ToString("#.00").Replace(",", ".") + "," + item.Produto.ID + "," + venda.ID + ")";
                    db.Database.ExecuteSqlCommand(sqlProdutoVenda);
                }
                               
                db.SaveChanges();
                return RedirectToAction("ConfirmarCompra", new { VendaID = venda.ID });
            }
            else
            {
                return RedirectToAction("~");
            }
            
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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
