using Fiap.Web.AspNet5.Controllers;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet5Test
{
    public class RepresentanteControllerTest
    {
        [Fact]
        public Task IndexReturnsViewResultViewList()
        {
            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns(ListaTreRepresentantes());

            var controller = new RepresentanteController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.ViewData.Model);

            Assert.NotEmpty(model);

            Assert.Equal(3, model.Count());

            return Task.CompletedTask;
        }

        [Fact]
        public Task IndexReturnsViewWithoutResult()
        {
            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns(new List<RepresentanteModel>());

            var controller = new RepresentanteController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.ViewData.Model);

            Assert.Empty(model);

            return Task.CompletedTask;
        }

        private List<RepresentanteModel> ListaTreRepresentantes()
        {
            return new List<RepresentanteModel>
            {
                new RepresentanteModel(1, "R1"),
                new RepresentanteModel(2, "R2"),
                new RepresentanteModel(3, "R3")
            };
        }

    }
}
