namespace BugTracking.Models
{
    public class AdminView
    {
        public int TotalBugCount { get; set; }
        public int TotalMessageCount { get; set; }
        public int TotalResolvedBugs { get; set; }
        public double BugResolutionRate { get; set; }
    }
}
