using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Services
{
    public class MatchException : Exception
    {
        public MatchException(string? message) : base(message)
        {
        }
    }
}
