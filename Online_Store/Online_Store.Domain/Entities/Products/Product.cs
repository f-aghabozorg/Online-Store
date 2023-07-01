using Online_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }


        //1-n relation of product-category
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }

        //1-n relation of product-ProductImages
        public virtual ICollection<ProductImages> ProductImages { get; set; }

        //1-n relation of product-ProductFeatures
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
    }
}
