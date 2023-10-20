﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperProjet.Models;

namespace SuperProjet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SuperProjet.Models.Truc> Trucs { get; set; } = default!;
        public DbSet<SuperProjet.Models.Problem> Problems { get; set; } = default!;
    }
}