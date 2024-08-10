using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Operations;
using InventoryManagement.Core.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Tests
{
    public class InventoryOperationsTests
    {
        [Fact]
        public void AddProduct_ValidInput_ProductIsAdded()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            var product = new Product("Test Product", 10.99m, 5);
            inventoryMock.Setup(x => x.AddProduct(It.IsAny<IProduct>()));
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Test Product\n10.99\n5");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var InventoryOperations = new InventoryOperations(inventory);

            // Act
            InventoryOperations.AddProduct();

            // Assert
            inventoryMock.Verify(x => x.AddProduct(It.Is<IProduct>(p => p.Name == "Test Product" && p.Price == 10.99m && p.Quantity == 5)), Times.Once);
            Assert.Contains("Product added successfully.", consoleOutput.ToString());
        }

        [Fact]
        public void AddProduct_EmptyProductName_ProductNameCannotBeEmpty()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("\n");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var InventoryOperations = new InventoryOperations(inventory);

            // Act
            InventoryOperations.AddProduct();

            // Assert
            Assert.Contains("Product name cannot be empty.", consoleOutput.ToString());
            inventoryMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Never);
        }

        [Fact]
        public void AddProduct_NegativePrice_PriceMustBePositive()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Test Product\n-10.99\n5");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var InventoryOperations = new InventoryOperations(inventory);

            // Act
            InventoryOperations.AddProduct();

            // Assert
            Assert.Contains("Price must be a positive number.", consoleOutput.ToString());
            inventoryMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Never);
        }

        [Fact]
        public void AddProduct_NegativeQuantity_QuantityMustBePositive()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Test Product\n10.99\n-5");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var InventoryOperations = new InventoryOperations(inventory);

            // Act
            InventoryOperations.AddProduct();

            // Assert
            Assert.Contains("Quantity must be a positive number.", consoleOutput.ToString());
            inventoryMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Never);
        }

        //-------------
        [Fact]
        public void ViewAllProducts_NoProducts_DisplaysNoProductsMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetAllProducts()).Returns(new List<IProduct>());
            var inventory = inventoryMock.Object;

            // Mock Console output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.ViewAllProducts();

            // Assert
            Assert.Contains("No products in the inventory.", consoleOutput.ToString());
        }

        [Fact]
        public void ViewAllProducts_WithProducts_DisplaysProducts()
        {
            // Arrange
            var products = new List<IProduct>
            {
                new Product("Product1", 10.99m, 5),
                new Product("Product2", 20.99m, 10)
            };
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetAllProducts()).Returns(products);
            var inventory = inventoryMock.Object;

            // Mock Console output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.ViewAllProducts();

            // Assert
            foreach (var product in products)
            {
                Assert.Contains(product.ToString(), consoleOutput.ToString());
            }
        }

        [Fact]
        public void ViewAllProducts_GetAllProductsThrowsException_DisplaysErrorMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetAllProducts()).Throws(new Exception("Test exception"));
            var inventory = inventoryMock.Object;

            // Mock Console output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.ViewAllProducts();

            // Assert
            Assert.Contains("An error occurred: Test exception", consoleOutput.ToString());
        }
        //----
        [Fact]
        public void DeleteProduct_ProductDoesNotExist_DisplaysProductNotFoundMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(It.IsAny<string>())).Returns((IProduct)null);
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Nonexistent Product");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.DeleteProduct();

            // Assert
            Assert.Contains("Product not found.", consoleOutput.ToString());
            inventoryMock.Verify(x => x.DeleteProduct(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void DeleteProduct_ProductExists_DeletesProductSuccessfully()
        {
            // Arrange
            var productName = "Existing Product";
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(productName)).Returns(new Product(productName, 10.99m, 5));
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader(productName);
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.DeleteProduct();

            // Assert
            Assert.Contains("Product deleted successfully.", consoleOutput.ToString());
            inventoryMock.Verify(x => x.DeleteProduct(productName), Times.Once);
        }

        [Fact]
        public void DeleteProduct_GetProductByNameThrowsException_DisplaysErrorMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(It.IsAny<string>())).Throws(new Exception("Test exception"));
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Some Product");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.DeleteProduct();

            // Assert
            Assert.Contains("Error: Test exception", consoleOutput.ToString());
        }
        //--
        [Fact]
        public void SearchProduct_ProductDoesNotExist_DisplaysProductNotFoundMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(It.IsAny<string>())).Returns((IProduct)null);
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Nonexistent Product");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.SearchProduct();

            // Assert
            Assert.Contains("Product not found.", consoleOutput.ToString());
        }

        [Fact]
        public void SearchProduct_ProductExists_DisplaysProductDetails()
        {
            // Arrange
            var productName = "Existing Product";
            var product = new Product(productName, 10.99m, 5);
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(productName)).Returns(product);
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader(productName);
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.SearchProduct();

            // Assert
            Assert.Contains(product.ToString(), consoleOutput.ToString());
        }

        [Fact]
        public void SearchProduct_GetProductByNameThrowsException_DisplaysErrorMessage()
        {
            // Arrange
            var inventoryMock = new Mock<Iinventory>();
            inventoryMock.Setup(x => x.GetProductByName(It.IsAny<string>())).Throws(new Exception("Test exception"));
            var inventory = inventoryMock.Object;

            // Mock Console input/output
            var consoleInput = new StringReader("Some Product");
            Console.SetIn(consoleInput);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var inventoryOperations = new InventoryOperations(inventory);

            // Act
            inventoryOperations.SearchProduct();

            // Assert
            Assert.Contains("Error: Test exception", consoleOutput.ToString());
        }

    }
}
