using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YearFive.Models;

namespace YearFive.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<YearFiveType> yearFiveTypes { get; set; }
        public DbSet<YearFive.Models.YearFiveTypeVM> YearFiveTypeVM { get; set; }
    }
}
