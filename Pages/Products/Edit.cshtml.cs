using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Pages.Products
{
    public class EditModel : ProductSkinTypesPageModel
    {
        private readonly Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext _context;

        public EditModel(Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(b => b.Category).Include(b => b.ProductSkinTypes).ThenInclude(b => b.SkinType).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
               
                return NotFound();
            }
            PopulateAssignedSkinTypeData(_context, Product);
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSkinTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Product.Include(i => i.Category).Include(i => i.ProductSkinTypes).ThenInclude(i => i.SkinType).FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(productToUpdate, "Product", i => i.ProductName, i => i.BrandName, i => i.Price, i => i.ManufactureDate, i => i.ExpirationDate, i => i.LotNo, i => i.Category))
            {
                UpdateProductSkinTypes(_context, selectedSkinTypes, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateProductSkinTypes(_context, selectedSkinTypes, productToUpdate);
            PopulateAssignedSkinTypeData(_context, productToUpdate);
            return Page();
            
                
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
