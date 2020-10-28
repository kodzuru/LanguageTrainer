using LanguageTrainer.Contracts;
using LanguageTrainer.Entities;
using LanguageTrainer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTrainer.Repository
{
    class User2ApplicationStateRepository : RepositoryBase<User2ApplicationState>, IUser2ApplicationState
    {
        public User2ApplicationStateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
