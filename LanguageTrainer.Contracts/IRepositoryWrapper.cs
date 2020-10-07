using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTrainer.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
