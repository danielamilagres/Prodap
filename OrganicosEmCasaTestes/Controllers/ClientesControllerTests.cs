using System;
using System.IO;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganicosEmCasa.Controllers;
using OrganicosEmCasa.Models;
using OrganicosEmCasaTestes.DbSet;

namespace OrganicosEmCasaTestes
{
    [TestClass]
    public class ClientesControllerTests
    {
        public TestContext TestContext { get; set; }
        private readonly ClientesController controller;
        private readonly IOrganicosEmCasaDBContext contexto;

        public ClientesControllerTests()
        {
            this.contexto = new TesteOrganicosEmCasaDBContext();
            this.controller = new ClientesController(this.contexto);
        }
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(context.TestDeploymentDir, string.Empty));
        }

        [TestMethod]
        public void TesteIndexView_Sucesso()
        {
            var resultado = this.controller.Index() as ViewResult;
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

           var resultado = this.controller.Create(cliente) as RedirectToRouteResult;

            Assert.AreEqual("Index", resultado.RouteValues["action"]);

            #region Remover dados
            this.contexto.Clientes.Remove(cliente);
            #endregion
        }

        [TestMethod]
        public void TesteDetailsAction_Sucesso()
        {
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

            contexto.Clientes.Add(cliente);
            #endregion

            var resultado = this.controller.Details(50) as ViewResult;
            var clienteRetornado = (Cliente)resultado.ViewData.Model;
            Assert.AreEqual(clienteRetornado.Nome, nomeCliente);

            #region Remover dados
            this.contexto.Clientes.Remove(cliente);
            #endregion
        }

        [TestMethod]
        public void TesteDetailsAction_NaoEncontrado()
        {
            var resultado = this.controller.Details(999);
            Assert.IsInstanceOfType(resultado, typeof(HttpNotFoundResult));
        }
    }
}
