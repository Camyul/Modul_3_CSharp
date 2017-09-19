using AspNetMvcFirstApp.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetMvcFirstApp.Tests.Controllers
{
    [TestFixture]
    public class StudentControllerTest
    {
        [Test]
        public void IndexShould_ReturnView_WhenInvocked()
        {
            //Arrange
            StudentsController stController = new StudentsController();

            //var stControllerMock = new Mock<IStudentsController>();
            //var resultMock = new Mock<ActionResult>();
            //stControllerMock.SetupGet(v => v.Index).Returns(resultMock as ActionResult);

            //Act

            ViewResult result = stController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
