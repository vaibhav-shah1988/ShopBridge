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
        /// <summary>
        /// Deletes Inventory based on Id
        /// </summary>
        /// <param name="Id">Inventory Id</param>
        public void DeleteInventory(int Id)
        {
            using (ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                var inv = shopBridge.Inventories.Find(Id);
                shopBridge.Inventories.Remove(inv);
                shopBridge.SaveChanges();
            }
        }

        /// <summary>
        /// Get List of Inventory
        /// </summary>
        /// <returns></returns>
        public IQueryable<Inventory> GetAllInventory()
        {
            using(ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                return shopBridge.Inventories.ToList().AsQueryable();
            }
        }

        /// <summary>
        /// Get inventory based on Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Inventory GetInventory(int Id)
        {
            using (ShopBridgeEntities shopBridge = new ShopBridgeEntities())
            {
                return shopBridge.Inventories.FirstOrDefault(x => x.Id == Id);
            }
        }

        /// <summary>
        /// Insert or update Inventory 
        /// </summary>
        /// <param name="inventory">Inventory object</param>
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
