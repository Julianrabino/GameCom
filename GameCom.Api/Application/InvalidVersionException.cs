using System;

namespace GameCom.Api.Application
{
    public class InvalidVersionException : Exception
    {
        public InvalidVersionException(string message) : base(message)
        {
        }
    }
}
