using System;
using System.IO;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganicosEmCasa.Controllers;
using OrganicosEmCasa.Models;

namespace OrganicosEmCasaTestes
{
    [TestClass]
    public class ClientesControllerTests
    {
        public TestContext TestContext { get; set; }
        private readonly ClientesController Controller;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(context.TestDeploymentDir, string.Empty));
        }

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new ClientesController();
            var resultado = controller.Index() as ViewResult;
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestCreateAction()
        {
            var cliente = new Cliente
            {
                Nome = "Daniela Milagres",
                Endereco = "Avenida do Contorno 3000",
                UF = OrganicosEmCasa.Utils.Estados.MG,
                Cidade = "Belo Horizonte",
                CPF = "486.475.170-67",
                CEP = "30.000-000",
                Telefone = "(31)98877-9878"
            };

            var controller = new ClientesController();
            var resultado = controller.Create(cliente);

            Assert.IsNotNull(resultado);
        }
    }
}
