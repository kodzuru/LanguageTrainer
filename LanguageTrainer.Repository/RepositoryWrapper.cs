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


        private IUser2ApplicationState user2ApplicationState;
        public IUser2ApplicationState User2ApplicationState
        {
            get
            {
                if (user2ApplicationState == null)
                {
                    user2ApplicationState = new User2ApplicationStateRepository(_context);
                }
                return user2ApplicationState;
            }
        }


        private IApplicationStateRepository applicationStateRepository;
        public IApplicationStateRepository ApplicationStateRepository
        {
            get
            {
                if (applicationStateRepository == null)
                {
                    applicationStateRepository = new ApplicationStateRepository (_context);
                }
                return applicationStateRepository;
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
