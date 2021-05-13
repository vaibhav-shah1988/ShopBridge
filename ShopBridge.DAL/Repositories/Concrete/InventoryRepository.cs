using ShopBridge.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.DAL.Repositories.Concrete
{
    public class InventoryRepository : IInventoryRepository
    {

        public void DeleteInventory(int Id)
        {
            using (ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                var inv = shopBridge.Inventories.Find(Id);
                shopBridge.Inventories.Remove(inv);
                shopBridge.SaveChanges();
            }
        }

        public IQueryable<Inventory> GetAllInventory()
        {
            using(ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                return shopBridge.Inventories.ToList().AsQueryable();
            }
        }

        public Inventory GetInventory(int Id)
        {
            using (ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                return shopBridge.Inventories.FirstOrDefault(x => x.Id == Id);
            }
        }

        public void SaveInventory(Inventory inventory)
        {
            using (ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                if(inventory.Id == 0)
                {
                    shopBridge.Inventories.Add(inventory);
                    shopBridge.SaveChanges();
                }
                else
                {
                    var data = shopBridge.Inventories.FirstOrDefault(x => x.Id == inventory.Id);
                    data.Name = inventory.Name;
                    data.Description = inventory.Description;
                    data.Price = inventory.Price;
                    shopBridge.SaveChanges();
                }
                
                
            }
        }
    }
}
