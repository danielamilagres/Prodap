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
        private IOrganicosEmCasaDBContext db;

        public HomeController()
        {
            this.db = new OrganicosEmCasaDBContext();
        }

        public HomeController(IOrganicosEmCasaDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }
    }
}