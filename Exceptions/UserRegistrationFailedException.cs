namespace BugTracking.Exceptions
{
    public class UserRegistrationFailedException : Exception
    {
        public UserRegistrationFailedException()
        {
            Console.WriteLine("This is UserRegistrationFailedException");
        }
    }
}
