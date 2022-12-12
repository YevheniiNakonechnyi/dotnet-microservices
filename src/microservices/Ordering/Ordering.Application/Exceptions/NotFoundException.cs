using System;

namespace Ordering.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            :base($"Entity \"{name}\" has not been found.")
        {
        }
    }
}
