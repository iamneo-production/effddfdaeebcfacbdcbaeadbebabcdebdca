using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class DealerControllerTests
    {
        private ApplicationDbContext _context;
        private DealerController _controller;

        [SetUp]
        public void Setup()
        {
            // Create an in-memory database for testing
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("InMemoryDatabase")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new ApplicationDbContext(options);

            // Seed the in-memory database with sample data
            _context.Dealers.AddRange(new List<Dealer>
            {
new Dealer { ID= 1, Name= "John Doe", RegistrationDate= DateTime.Parse("1990-05-15"), AutoPartName= "Male", Manufacturer= "A+", MobileNumber= "123-456-7890", Email= "johndoe@example.com", Description= "New York" },
new Dealer {ID= 2, Name= "Jane Smith", RegistrationDate= DateTime.Parse("1985-08-20"), AutoPartName= "Female", Manufacturer= "B-", MobileNumber= "987-654-3210", Email= "janesmith@example.com", Description= "Los Angeles"},
new Dealer {ID= 3, Name= "Robert Johnson", RegistrationDate= DateTime.Parse("1992-03-10"), AutoPartName= "Male", Manufacturer= "O+", MobileNumber= "555-123-4567", Email= "robertjohnson@example.com", Description= "Chicago"},
new Dealer {ID= 4, Name= "Emily Brown", RegistrationDate= DateTime.Parse("1980-12-05"), AutoPartName= "Female", Manufacturer= "AB+", MobileNumber= "777-999-8888", Email= "emilybrown@example.com", Description= "Houston"}
        });
            _context.SaveChanges();

            _controller = new DealerController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the in-memory database after each test
            _context.Dispose();
        }
        //This test checks the Index Action method in DealerController
        [Test]
        public void Index_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

         //This test checks the Create Action method in DealerController
        [Test]
        public void Create_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Create", new Type[0]) != null,
                Is.True, "Create action does not exist."
            );
        }
         //This test checks the Delete Action method in DealerController
        [Test]
        public void Delete_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Delete",  new[] { typeof(int) }) != null,
                Is.True, "Delete action does not exist."
            );
        }

         //This test checks the DealerController exist or not
         [Test]
public void DealerController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Dealer";
    string controllerNamespace = "dotnetapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}

 //This test checks the ApplicationDbContext available or not
 [Test]
        public void ApplicationDbContext_Class_Available()
        {
            // Arrange
            Type ApplicationDbContextType = typeof(ApplicationDbContext);

            // Act & Assert
            Assert.IsNotNull(ApplicationDbContextType, "ApplicationDbContext class not found.");
        }
 //This test checks the Dealer class available or not
         [Test]
        public void Dealer_Class_Available()
        {
            // Arrange
            Type DealerType = typeof(Dealer);

            // Act & Assert
            Assert.IsNotNull(DealerType, "Dealer class not found.");
        }
         //This test checks the Dealer class has AutoPartName property with string datatype
        [Test]
        public void Dealer_Properties_AutoPartName_ReturnExpectedDataTypes()
        {
            // Arrange
            Dealer Dealer = new Dealer();
            PropertyInfo propertyInfo = Dealer.GetType().GetProperty("AutoPartName");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "AutoPartName property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "AutoPartName property type is not string.");
        }
        //This test checks the Dealer class has Name property with string datatype
        [Test]
        public void Dealer_Properties_Name_ReturnExpectedDataTypes()
        {
            // Arrange
            Dealer Dealer = new Dealer();
            PropertyInfo propertyInfo = Dealer.GetType().GetProperty("Name");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "Name property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "Name property type is not string.");
        }
        //This test checks the Dealer class has Manufacturer property with string datatype
        [Test]
        public void Dealer_Properties_Manufacturer_ReturnExpectedDataTypes()
        {
            // Arrange
            Dealer Dealer = new Dealer();
            PropertyInfo propertyInfo = Dealer.GetType().GetProperty("Manufacturer");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "Manufacturer property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "Manufacturer property type is not string.");
        }
        //This test checks the DealerController Index returns ViewResult of list of Dealers
        [Test]
        public void Index_ReturnsViewWithDealers()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Dealer>;
            Assert.IsNotNull(model);
            Assert.AreEqual(4, model.Count);
        }
//This test checks the DealerController has Create action that returns ViewResult
       [Test]
public void Create_GET_ReturnsView()
{
    // Act
    var result = _controller.Create() as ViewResult;

    // Assert
    Assert.IsNotNull(result);
}
//This test checks the DealerController has Create action with Post Dealer data. On successful adding the page redirects to Index
[Test]
public void Create_POST_ValidModel_RedirectsToIndex()
{
    // Arrange
    var Dealer = new Dealer
    {
        Name= "Michael Wilson", RegistrationDate= DateTime.Parse("1995-07-25"), AutoPartName= "Male", Manufacturer= "A-", MobileNumber= "444-333-2222", Email= "michaelwilson@example.com", Description= "Miami"
    };

    // Act
    var result = _controller.Create(Dealer) as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ActionName);
}

//This test checks the DealerController has Delete action with dealer invalid id redirects to NotFoundResult
[Test]
public void Delete_POST_InvalidId_ReturnsNotFound()
{
    // Act
    var result = _controller.Delete(7);

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<NotFoundResult>(result);
}
//This test checks the DealerController has Delete action with dealer id, after deletes the action redirects to Index
[Test]
    public void Delete_WhenDealerExists_ReturnsRedirectToAction()
    {
        // Arrange
        int dealerId = 1;
        var result = _controller.Delete(dealerId) as RedirectToActionResult;
        // Assert
        // Verify that the dealer was removed from the in-memory database
        var deletedDealer = _context.Dealers.Find(dealerId);
        Assert.IsNull(deletedDealer);
        Assert.IsNotNull(result);
        Assert.AreEqual(nameof(_controller.Index), result.ActionName);
    }
//This test checks the DealerController has Delete action with dealer invalid id redirects to NotFoundResult
    [Test]
    public void Delete_WhenDealerDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        int dealerId = 999; // Assuming a non-existing ID

        // Act
        var result = _controller.Delete(dealerId) as NotFoundResult;

        // Assert
        Assert.IsNotNull(result);
    }
    }
}
