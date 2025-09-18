using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Models
{
    public class ProductsFilter
    {
        public int? SubCategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
    }
}
