using LanguageTrainer.Contracts;
using LanguageTrainer.Entities;
using LanguageTrainer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTrainer.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
