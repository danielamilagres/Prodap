using OrganicosEmCasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganicosEmCasa.Controllers
{
    public class HomeController : Controller
    {
        private OrganicosEmCasaDBContext db = new OrganicosEmCasaDBContext();
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }
    }
}