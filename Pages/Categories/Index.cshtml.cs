﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext _context;

        public IndexModel(Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data.Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
