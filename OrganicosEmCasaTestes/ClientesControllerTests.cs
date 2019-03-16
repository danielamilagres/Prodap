using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganicosEmCasa.Controllers;

namespace OrganicosEmCasaTestes
{
    [TestClass]
    public class ClientesControllerTests
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new ClientesController();
            var resultado = controller.Index() as ViewResult;
        }
    }
}
