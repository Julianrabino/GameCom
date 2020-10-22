using System;

namespace GameCom.Model.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string message) : base(message)
        {
        }
    }
}
