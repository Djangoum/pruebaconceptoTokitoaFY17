using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCutting.Exceptions
{
    public class UserLoginException : Exception
    {
        public UserLoginException(string Message) : base(Message)
        {

        }
    }
}
