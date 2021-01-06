using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext _context;

        public IndexModel(Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int SkinTypeID { get; set; }

        public async Task OnGetAsync(int? id, int? skinTypeID)
        {
            ProductD = new ProductData();
            ProductD.Products = await _context.Product.Include(b=>b.Category).Include(b => b.ProductSkinTypes).ThenInclude(b => b.SkinType).AsNoTracking().OrderBy(b => b.ProductName).ToListAsync();
            if(id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products.Where(i => i.ID == id.Value).Single();
                ProductD.SkinTypes = product.ProductSkinTypes.Select(s => s.SkinType);
            }
        }
    }
}
