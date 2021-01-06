using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Tipul de produs")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
