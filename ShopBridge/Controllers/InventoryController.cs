using ShopBridge.DAL.Entities;
using ShopBridge.DAL.Repositories;
using ShopBridge.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class InventoryController : ApiController
    {
        private IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        /// <summary>
        /// Gets List of All Inventory
        /// </summary>
        /// <returns>List of Inventory Object</returns>
        [HttpGet]
        public IQueryable<Inventory> GetAllInventory()
        {
            var inv = _inventoryRepository.GetAllInventory();
            return inv;
        }

        /// <summary>
        /// Gets single Inventory bsed on inventoryid
        /// </summary>
        /// <param name="Id">InventoryId</param>
        /// <returns> HTTP result </returns>
        [HttpGet]
        public IHttpActionResult GetInventory(int Id)
        {
            try
            {
                var inv = _inventoryRepository.GetInventory(Id);

                if (inv == null)
                {
                    return NotFound();
                }

                return Ok(inv);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        
        public IHttpActionResult PostInventory([FromBody] Inventory inventory)
        {
            try
            {
                if(inventory == null || !ModelState.IsValid)
                {
                    return BadRequest("Bad Request");
                }

                _inventoryRepository.SaveInventory(inventory);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteInventory(int Id)
        {
            try
            {
                _inventoryRepository.DeleteInventory(Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
