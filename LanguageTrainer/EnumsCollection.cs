using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageTrainer
{
    public static class EnumsCollection
    {
        public enum CommandResponsibility : byte
        {
            Keyboard,
            Inline
        }
        public enum ApplicationState : byte
        {
            NOT_REGISTRATED = 1,
            STARTED,
            RESTARTED,
            INSERTING_WORDS,
            TRAINING_WORDS,
            OPTIONS
        }
    }
}
