using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Constracts.Inventory
{
    public class CreateInventory
    {
        [Range(1,100000000000000 , ErrorMessage = "محصول را انتخاب کنید")]
        public long ProductId { get; set; }
        [Range(1,10000000000000000 , ErrorMessage = "قیمت را وارد کنید")]
        public double Price { get; set; }
        public IList Products { get; set; }
    }

}
