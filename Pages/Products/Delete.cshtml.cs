﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext _context;

        public DeleteModel(Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context)
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

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
