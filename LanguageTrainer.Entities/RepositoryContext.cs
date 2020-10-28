using LanguageTrainer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LanguageTrainer.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options ?? new DbContextOptions<RepositoryContext>())
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }
        public DbSet<User2ApplicationState> User2ApplicationStates { get; set; }
    }
}
