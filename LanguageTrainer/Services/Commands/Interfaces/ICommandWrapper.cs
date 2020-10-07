using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageTrainer.Services.Commands
{
    public interface ICommandWrapper
    {
        List<CommandBase> Commands { get; set; }

    }
}
