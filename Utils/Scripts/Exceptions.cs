using System;

namespace HYDRA
{
    public class PreconditionException : Exception
    {
        public PreconditionException() { }

        public PreconditionException(string message) : base(message) { }
    }
}