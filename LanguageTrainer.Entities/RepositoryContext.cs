using LanguageTrainer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LanguageTrainer.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base (options ?? new DbContextOptions<RepositoryContext>())
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }



        public DbSet<User> Users { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }
        public DbSet<User2ApplicationState> User2ApplicationStates { get; set; }
    }
}
