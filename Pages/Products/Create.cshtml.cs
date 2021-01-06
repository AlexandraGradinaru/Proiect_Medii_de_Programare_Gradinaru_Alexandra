using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Pages.Products
{
    public class CreateModel : ProductSkinTypesPageModel
    {
        private readonly Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext _context;

        public CreateModel(Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            var product = new Product();
            product.ProductSkinTypes = new List<ProductSkinType>();
            PopulateAssignedSkinTypeData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedSkinTypes)
        {
            var newProduct = new Product();
            if (selectedSkinTypes != null)
            {
                newProduct.ProductSkinTypes = new List<ProductSkinType>();
                foreach(var skin in selectedSkinTypes)
                {
                    var skinToAdd = new ProductSkinType
                    {
                        SkinTypeID = int.Parse(skin)
                    };
                    newProduct.ProductSkinTypes.Add(skinToAdd);
                }
            }
            if(await TryUpdateModelAsync<Product>(newProduct, "Product", i => i.ProductName, i => i.BrandName, i => i.Price, i => i.ManufactureDate, i => i.ExpirationDate, i => i.LotNo, i => i.CategoryID))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedSkinTypeData(_context, newProduct);
            return Page();
        }
    }
}
