using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data
{
    public class Proiect_Medii_de_Programare_Gradinaru_AlexandraContext : DbContext
    {
        public Proiect_Medii_de_Programare_Gradinaru_AlexandraContext (DbContextOptions<Proiect_Medii_de_Programare_Gradinaru_AlexandraContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models.Product> Product { get; set; }

        public DbSet<Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models.Category> Category { get; set; }

        public DbSet<Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models.SkinType> SkinType { get; set; }
    }
}
