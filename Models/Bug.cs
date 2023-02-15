namespace BugTracking.Models
{
    public enum BugStatus
    {
        Resolved,
        Open,
        Working
    }
    //Bug Model
    public class Bug
    {
        public int BugId { get; set; }
        public int ProjectId { get; set; }
        public BugStatus Status { get; set; }
        /*public ICollection<Message> Messages { get; set; }*/
    }
}
