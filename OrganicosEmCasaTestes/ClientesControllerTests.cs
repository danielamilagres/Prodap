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

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(context.TestDeploymentDir, string.Empty));
        }

        [TestMethod]
        public void TesteIndexView_Sucesso()
        {
            var controller = new ClientesController();
            var resultado = controller.Index() as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Index", resultado.ViewName);
        }

        [TestMethod]
        public void TesteCreateAction_Sucesso()
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
            var resultado = controller.Create(cliente) as RedirectToRouteResult;

            Assert.AreEqual("Index", resultado.RouteValues["action"]);
        }

        [TestMethod]
        public void TesteDetailsAction_Sucesso()
        {
            var controller = new ClientesController();
            var nomeCliente = "João Paulo Silva";

            #region Criar Registro
            var cliente = new Cliente
            {
                ID = 50,
                Nome = nomeCliente,
                Endereco = "Avenida do Contorno 3000",
                UF = OrganicosEmCasa.Utils.Estados.MG,
                Cidade = "Belo Horizonte",
                CPF = "486.475.170-67",
                CEP = "30.000-000",
                Telefone = "(31)98877-9878"
            };

            controller.Create(cliente);
            #endregion

            var resultado = controller.Details(1) as ViewResult;
            var clienteRetornado = (Cliente)resultado.ViewData.Model;
            Assert.AreEqual(clienteRetornado.Nome, nomeCliente);

            #region Remoção registro
            controller.DeleteConfirmed(clienteRetornado.ID);
            #endregion
        }

        [TestMethod]
        public void TesteDetailsAction_NaoEncontrado()
        {
            var controller = new ClientesController();
            var resultado = controller.Details(999);
            Assert.IsInstanceOfType(resultado, typeof(HttpNotFoundResult));
        }
    }
}
