using Microsoft.EntityFrameworkCore;
using System;
using TestWebApp.Models;

namespace MVC.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        public DbSet<Student> Students { get; set; }
    }
}
