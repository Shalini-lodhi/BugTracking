namespace BugTracking.Exceptions
{
    public class LoginFailedException : Exception 
    {
        public LoginFailedException()
        {
            Console.WriteLine("This is a LoginFailedException");
        }
    }
}
