using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class ProductSkinType
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int SkinTypeID { get; set; }
        public SkinType SkinType { get; set; }
    }
}
