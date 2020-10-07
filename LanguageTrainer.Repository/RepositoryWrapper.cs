using LanguageTrainer.Contracts;
using LanguageTrainer.Entities;

namespace LanguageTrainer.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
