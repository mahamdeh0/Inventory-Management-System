using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Operations
{

    public class InventoryOperations
    {
        private readonly Iinventory _inventory;

        public InventoryOperations(Iinventory inventory)
        {
            _inventory = inventory;
        }


    }
}

