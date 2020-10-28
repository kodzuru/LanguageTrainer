using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTrainer.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        IUser2ApplicationState User2ApplicationState { get; }
        IApplicationStateRepository ApplicationStateRepository { get; }
        void Save();
    }
}
