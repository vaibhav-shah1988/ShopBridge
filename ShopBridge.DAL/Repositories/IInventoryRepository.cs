using ShopBridge.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.DAL.Repositories
{
    public interface IInventoryRepository
    {
        IQueryable<Inventory> GetAllInventory();
        Inventory GetInventory(int Id);
        void SaveInventory(Inventory inventory);
        void DeleteInventory(int Id);
    }
}
