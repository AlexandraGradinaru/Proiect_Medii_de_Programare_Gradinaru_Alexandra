using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SkinType> SkinTypes { get; set; }
        public IEnumerable<ProductSkinType> ProductSkinTypes { get; set; }
    }
}
