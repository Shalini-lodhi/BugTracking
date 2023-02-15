namespace BugTracking.Models
{
    //Message Model
    public class Message
    {
        public int MessageId { get; set; }
        public int BugId { get; set; }
        public int SubmissionId { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }
    }
}
