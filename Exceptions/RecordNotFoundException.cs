namespace BugTracking.Exceptions
{
    public class RecordNotFoundException : Exception {
        public RecordNotFoundException()
        {
            Console.WriteLine("This is a RecordNotFoundException");
        }
    }
}
