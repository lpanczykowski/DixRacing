using System;

namespace DixRacing.Domain.SharedKernel.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, string entityId) : base(
        $"{entityName} Id=[{entityId}] does not exist")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

    }
}