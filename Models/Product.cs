using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Denumire Produs")]
        public string ProductName { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Marca")]
        public string BrandName { get; set; }
        [Range(1,400)]
        [Display(Name = "Pret")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [Display(Name = "Data Fabricarii")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
        [Display(Name = "Data Expirarii")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        [Display(Name = "NrLot")]
        public string LotNo { get; set; } 
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Tipuri de ten")]
        public ICollection<ProductSkinType> ProductSkinTypes { get; set; }


    }
}
