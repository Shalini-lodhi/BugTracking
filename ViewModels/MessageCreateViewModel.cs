namespace BugTracking.ViewModels
{
    //Creating new Message in Bug
    public class MessageCreateViewModel
    {
        public int BugId { get; set; }
        public int SubmissionId { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }
    }
}
