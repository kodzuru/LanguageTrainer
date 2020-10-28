using LanguageTrainer.Contracts;
using LanguageTrainer.Entities;
using LanguageTrainer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTrainer.Repository
{
    class ApplicationStateRepository : RepositoryBase<ApplicationState>, IApplicationStateRepository
    {
        public ApplicationStateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
