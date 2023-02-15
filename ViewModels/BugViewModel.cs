using BugTracking.Models;

namespace BugTracking.ViewModels
{
    public class BugViewModel
    {
        public int BugId { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
    }
}
