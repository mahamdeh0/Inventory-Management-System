using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interfaces
{
    public interface Iinventory
    {
        void AddProduct(IProduct product);
        void DeleteProduct(string productName);
        void UpdateProduct(IProduct product);
        IProduct GetProductByName(string productName);
        IEnumerable<IProduct> GetAllProducts();
    }
}
