using BugTracking.ViewModels;

namespace BugTracking.Services
{
    public interface IBugTrackingService
    {
        //Displaying all the project
        Task<IEnumerable<ProjectViewModel>> GetAllProjectAsync();
        
        //Creating new Project
        Task<ProjectViewModel> CreateProjectAsync(ProjectCreateViewModel projectModel);

        //Getting project through Id
        Task<ProjectViewModel> GetProjectByIdAsync(int projectId);

        /*---------------------------------------------------------------------------------*/

        //Getting All the bugs in the project
        Task<IEnumerable<BugViewModel>> GetAllBugsInProjectAsync(int projectId);

        //Getting bug through Id
        Task<BugViewModel> GetBugByIdAsync(int bugId);

        //Creating Bugs
        Task<BugViewModel> CreateBugAsync(BugCreateViewModel bugModel, int projectId);

        /*---------------------------------------------------------------------------------*/

        //Grrting All the message in the project
        Task<IEnumerable<MessageViewModel>> GetAllMessagesInBugAsync(int bugId);

        //Getting message through Id
        Task<MessageViewModel> GetMessageByIdAsync(int messageId);

        //Creating Message
        Task<MessageViewModel> CreateMessageAsync(MessageCreateViewModel messageModel, int bugId);

        //DashBoard
    }
}
