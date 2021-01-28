using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

using AppConfigTest.Infrastructure;
using AppConfigTest.Controllers;
using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppConfig.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void ControllerTest()
        {
            var products = new[] { new Product { Name = "Test", Price = 1000m } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(p => p.Products).Returns(products);
            HomeController controller = new HomeController(mock.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.Equal(products, result.ViewData.Model);

        }

        //[Fact]
        //public void ControllerAltTest()
        //{
        //    var products = new[] { new Product { Name = "AltTest", Price = 1000m } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(p => p.Products).Returns(products);
        //    TypeBroker.SetTestObject(mock.Object);

        //    HomeController controller = new HomeController();

        //    ViewResult result = controller.Index() as ViewResult;

        //    Assert.Equal(products, result.ViewData.Model);

        //}
    }
}
