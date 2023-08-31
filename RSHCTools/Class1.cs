using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;

namespace RSHCTools
{
    public interface ILogger
    {
    }

    public enum SignInStatus
    {
     Success = 1,
     LockedOut = 2,
     RequiresVerification = 3,
     Failure = 4,
    }
}
