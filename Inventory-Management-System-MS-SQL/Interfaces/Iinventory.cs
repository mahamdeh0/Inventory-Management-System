namespace Inventory_Management_System.Interfaces
{
    public interface Iinventory
    {
        Task AddProduct(IProduct product);
        Task DeleteProduct(string productName);
        Task UpdateProduct(IProduct product);
        Task<List<IProduct>> GetProductByName(string productName);
        Task<List<IProduct>> GetAllProducts();
    }
}
