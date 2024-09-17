using Inventory_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Models
{
    public class Inventory : Iinventory
    {
        private readonly List<IProduct> _products;


        public Inventory()
        {
            _products = new List<IProduct>(); 
        }

        public void AddProduct(IProduct product)
        {
           
            _products.Add(product);
        }

        IEnumerable<IProduct> Iinventory.GetAllProducts() => _products;

        void Iinventory.UpdateProduct(IProduct product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name.Equals(product.Name));
            if (existingProduct != null)
            {
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Quantity = product.Quantity;
                }
            }
        }

        void Iinventory.DeleteProduct(string productName)
        {
            var product = _products.FirstOrDefault(x => x.Name.Equals(productName));
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        IProduct Iinventory.GetProductByName(string productName)
        {
            return _products.FirstOrDefault(p => p.Name.Equals(productName));
        }


    }
}
