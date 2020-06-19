using System;
using System.Collections.Generic;
using System.Text;
using GUI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
            public DbSet<ImageDetails> ImageDetails { get; set; }
            public DbSet<ProcessImgDetails> ProcessImgDetails { get; set; }
    }
}
