# Simple Inventory Management System

Welcome to the **Simple Inventory Management System**! This console-based application allows you to manage a list of products, where each product has a name, price, and quantity in stock. The system supports basic operations such as adding, viewing, editing, deleting, and searching for products.

## Features

- **Add a Product:** Prompt for product name, price, and quantity, then add the product to the inventory.
- **View All Products:** Display a list of all products with their prices and quantities.
- **Edit a Product:** Update the details of an existing product in the inventory.
- **Delete a Product:** Remove a product from the inventory by its name.
- **Search for a Product:** Find a product by its name and display its details.
- **Exit:** Close the application.

## Code Structure

- `InventoryManagement/`: Contains the main application code.
  - `Interfaces/`: Defines interfaces for products and inventory.
  - `Models/`: Contains classes representing products and inventory.
  - `Operations/`: Implements business logic for inventory operations.
  - `Utilities/`: Includes utility classes for menu display and other functionalities.
  - `Program.cs`: Entry point of the application.

- `InventoryManagement.Tests/`: Contains unit tests for the application.
  - `ProductTests.cs`: Tests for the `Product` class.
  - `InventoryOperationsTests.cs`: Tests for the `InventoryOperations` class.


## Unit Testing

Unit tests have been added to ensure the system's functionality. 

## Principles Applied

- **Single Responsibility Principle:** Each class and method has a single, well-defined responsibility.
- **Open/Closed Principle:** The system design allows for extending functionalities without modifying existing code.
- **Liskov Substitution Principle:** Interfaces ensure substitutability of components.
- **Interface Segregation Principle:** Interfaces are specific to their functionalities, avoiding unnecessary implementations.
- **Dependency Inversion Principle:** High-level modules depend on abstractions rather than concrete implementations.

## Validation and Error Handling

- **Input Validation:** Ensures data integrity by checking for valid inputs (e.g., non-empty names, positive numbers).
- **Error Handling:** Uses try-catch blocks to handle exceptions and provide user-friendly error messages.
