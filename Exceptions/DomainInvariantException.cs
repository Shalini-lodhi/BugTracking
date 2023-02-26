using System;
namespace BugTracking.Exceptions
{
    public class DomainInvariantException:Exception
    {
        public DomainInvariantException()
        {
            Console.WriteLine("This is a DomainInvariantException");
        }
    }
}
