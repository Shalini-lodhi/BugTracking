using BugTracking.Models;

namespace BugTracking.ViewModels
{
    public class BugCreateViewModel
    {
        public int ProjectId { get; set; }
        public BugStatus Status { get; set; }
        /*public ICollection<Message> Messages { get; set; }*/
    }
}
