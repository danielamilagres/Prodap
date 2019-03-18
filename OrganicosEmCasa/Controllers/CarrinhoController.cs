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
    public class CarrinhoController : Controller
    {
        private readonly IOrganicosEmCasaDBContext db;

        public CarrinhoController()
        {
            this.db = new OrganicosEmCasaDBContext();
        }

        public CarrinhoController(IOrganicosEmCasaDBContext db)
        {
            this.db = db;
        }

        public ActionResult AdicionarCarrinho(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto != null)
            {
                if (Session["carrinho"] == null)
                {
                    List<Carrinho> carrinho = new List<Carrinho>();
                    carrinho.Add(new Carrinho());
                    carrinho[0].ListaDeItens = new List<ItemCarrinho>();
                    carrinho[0].ListaDeItens.Add(new ItemCarrinho(produto, 1));
                    Session["carrinho"] = carrinho;
                }
                else
                {
                    List<Carrinho> carrinho = (List<Carrinho>)Session["carrinho"];
                    int index = ExisteNoCarrinho(id);
                    if (index != -1)
                    {
                        carrinho[0].ListaDeItens[index].Quantidade++;
                    }
                    else
                    {
                        carrinho[0].ListaDeItens.Add(new ItemCarrinho(produto, 1));
                    }
                    Session["carrinho"] = carrinho;

                }
            }
            else
                return RedirectToAction("Error");
            return RedirectToAction("Carrinho");
        }

        public ActionResult Remover(int id)
        {
            if (Session["carrinho"] != null)
            {
                List<Carrinho> carrinho = (List<Carrinho>)Session["carrinho"];
                int index = ExisteNoCarrinho(id);
                if (index != -1)
                {
                    var item = carrinho.First().ListaDeItens[index];
                    carrinho.First().ListaDeItens.Remove(item);
                }
                Session["carrinho"] = carrinho;

                if (carrinho.First().ListaDeItens.Count() == 0)
                    LimparCarrinho();
            }
            return RedirectToAction("Carrinho");
        }

        public ActionResult LimparCarrinho()
        {
            Session["carrinho"] = null;
            return RedirectToAction("Carrinho");
        }
        private int ExisteNoCarrinho(int id)
        {
            List<Carrinho> carrinho = (List<Carrinho>)Session["carrinho"];
            for (int i = 0; i < carrinho[0].ListaDeItens.Count; i++)
                if (carrinho[0].ListaDeItens[i].Produto.ID.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Carrinho()
        {
            return View((List<Carrinho>)Session["carrinho"]);
        }
    }
}