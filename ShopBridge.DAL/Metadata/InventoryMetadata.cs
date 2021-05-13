using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.DAL.Entities
{
    public class InventoryMetadata
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    [MetadataType(typeof(InventoryMetadata))]
    public partial class Inventory
    {

    }
}
