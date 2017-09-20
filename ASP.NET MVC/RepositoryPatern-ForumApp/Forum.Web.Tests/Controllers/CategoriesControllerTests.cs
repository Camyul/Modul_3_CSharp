using Forum.Data.Common;
using Forum.Models;
using Forum.Web.Contracts;
using Forum.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Web.Tests.Controllers
{
    [TestFixture]
    class CategoriesControllerTests
    {
        [Test]
        public void IndexShould()
        {
            // Assert
            var categories = new List<Category>
                    {
                        new Category {Id = 1, Name = "Home", ParentCategory = null},
                        new Category {Id = 2, Name = "News", ParentCategory = null},
                        new Category {Id = 3, Name = "Test", ParentCategory = null},
                    };

            var repository = new Mock<IRepository<Category>>();
            repository.Setup(e => e.All).Returns(categories.AsQueryable());

            var unitOfWork = new Mock<IEfUnitOfWork>();

            var controller = new CategoriesController(repository.Object, unitOfWork.Object);

            //Act
            
            var result = controller.Index() as ViewResult;
            // var model = result.Model as CategoriesViewModel;

            //Assert

            Assert.IsNotNull(result);
            //Assert.AreEqual(3, model.All.Count());
        }
    }
}
