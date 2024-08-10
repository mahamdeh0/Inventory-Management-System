using InventoryManagement.Core.Models;

namespace Inventory_Management_System.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ValidInput_InitializesProperties()
        {
            // Arrange
            string expectedName = "TestProduct";
            decimal expectedPrice = 99.99m;
            int expectedQuantity = 10;

            // Act
            var Actual = new Product(expectedName, expectedPrice, expectedQuantity);

            // Assert
            Assert.Equal(expectedName, Actual.Name);
            Assert.Equal(expectedPrice, Actual.Price);
            Assert.Equal(expectedQuantity, Actual.Quantity);
        }

        [Fact]
        public void ToString_ValidInput_ReturnsFormattedString()
        {
            // Arrange
            var product = new Product("TestProduct", 99.99m, 10);
            string expectedString = "Name: TestProduct, Price: 99.99, Quantity: 10";

            // Act
            var Acutal = product.ToString();

            // Assert
            Assert.Equal(expectedString, Acutal);
        }
    }
}