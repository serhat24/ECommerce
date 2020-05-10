using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.Models.Entities
{

    public class Category : BaseModel
    {
        public int CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public IList<Product> Products { get; set; }

    }

}
