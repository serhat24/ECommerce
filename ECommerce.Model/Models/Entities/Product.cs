using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.Models.Entities
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public bool Discontinued { get; set; }
        public IList<Category> Categories { get; set; }

    }
}
