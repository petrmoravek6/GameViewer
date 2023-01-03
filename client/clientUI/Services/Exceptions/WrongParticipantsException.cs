using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Services.Exceptions
{
    public class WrongParticipantsException : MatchException
    {
        public WrongParticipantsException(string? message) : base(message)
        {
        }
    }
}
