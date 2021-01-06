using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class SkinType
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Tipul de ten")]
        public string SkinTypeName { get; set; }
        public ICollection<ProductSkinType> ProductSkinTypes { get; set; }
    }
}
