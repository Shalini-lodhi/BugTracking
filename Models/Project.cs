namespace BugTracking.Models
{
    //Project Model
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        //public ICollection<Bug> Bugs { get; set; }
    }
}
