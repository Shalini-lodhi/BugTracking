namespace BugTracking.ViewModels
{
    //display everthing in Message Model
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public int BugId { get; set; }
        public int SubmissionId { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }
    }
}
