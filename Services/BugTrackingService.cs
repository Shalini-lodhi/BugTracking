using BugTracking.DAL;
using BugTracking.Models;
using BugTracking.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Net.Mime.MediaTypeNames;

//Data accessing layer
namespace BugTracking.Services
{
    public class BugTrackingService : IBugTrackingService
    {
        //accessing data
        public readonly BugTrackingContext _context;

        public BugTrackingService(BugTrackingContext context)
        {
            _context = context;
        }

        //
        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectAsync()
        {
            return await _context.Projects
                .Select(p => new ProjectViewModel
                {
                    ProjectId = p.ProjectId,
                    Title = p.Title,
                    Owner = p.Owner
                }).ToListAsync();
        }

        //Create Project
        public async Task<ProjectViewModel> CreateProjectAsync(ProjectCreateViewModel project)
        {
            var p = ToProjectEntity(project);
            await _context.AddAsync(p);
            await _context.SaveChangesAsync();
            return ToProjectViewModel(p);
        }

        //Getting project through Id
        public async Task<ProjectViewModel> GetProjectByIdAsync(int p_id)
        {
            return ToProjectViewModel(await FromProjectId(p_id));
        }


        /*----------------------------------------------*/
        //Getting all the Bugs
        public async Task<IEnumerable<BugViewModel>> GetAllBugsInProjectAsync(int projectId)
        {
            return await _context.Bugs.Where(b=>b.ProjectId==projectId)
                .Select(b => new BugViewModel
                {
                    BugId = b.BugId,
                    ProjectId = projectId,
                    Status = b.Status.ToString()
                })
                .ToListAsync();
        }
        //Getting bug through Id
        public async Task<BugViewModel> GetBugByIdAsync(int b_id)
        {
            return ToBugViewModel(await FromBugId(b_id));
        }
        //Create Bug
        public async Task<BugViewModel> CreateBugAsync(BugCreateViewModel bug, int projectid)
        {
            var b = ToBugEntity(bug);
            b.ProjectId = projectid;
            b.Status = BugStatus.Open;
            await _context.AddAsync(b);
            await _context.SaveChangesAsync();
            return ToBugViewModel(b);
        }


        /*----------------------------------------------*/
        //1. Getting all the Message
        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesInBugAsync(int bugId)
        {
            return await _context.Messages
                .Select(m => new MessageViewModel
                {
                    MessageId = m.MessageId,
                    BugId = bugId,
                    SubmissionId = m.SubmissionId,
                    Text = m.Text,
                    IsResolved = m.IsResolved 
                })
                .ToListAsync();
        }
        //Getting Message through Id
        public async Task<MessageViewModel> GetMessageByIdAsync(int m_id)
        {
            return ToMessageViewModel(await FromMessageId(m_id));
        }

        //Create Message
        public async Task<MessageViewModel> CreateMessageAsync(MessageCreateViewModel message, int bugId)
        {
            var m = ToMessageEntity(message);
            m.BugId = bugId;
            m.SubmissionId= message.SubmissionId;
            m.Text = message.Text;
            m.IsResolved = message.IsResolved;
                
            var messageCount = await _context.Messages.Where(b => b.BugId == bugId).CountAsync();
            var bug = await _context.Bugs.FirstAsync(b => b.BugId == bugId);
            if (bug.Status == BugStatus.Resolved)
            {
                return null;
            }
            if (messageCount == 0)
            {
                if (bug.Status == BugStatus.Resolved)
                    bug.Status = BugStatus.Working;
            }
            if (m.IsResolved)
                bug.Status = BugStatus.Resolved;
            await _context.AddAsync(m);
            await _context.SaveChangesAsync();

            return ToMessageViewModel(m);
        }

        /*----------------------------------------------*/

        //From Id Method
        private async Task<Project> FromProjectId(int id)
        {
            return await _context.Projects.FirstAsync(p => p.ProjectId == id);
        }
        private async Task<Bug> FromBugId(int id)
        {
            return await _context.Bugs.FirstAsync(p => p.BugId == id);
        }
        private async Task<Message> FromMessageId(int id)
        {
            return await _context.Messages.FirstAsync(m => m.MessageId == id);
        }
        /*----------------------------------------------*/

        //To View Model
        private ProjectViewModel ToProjectViewModel(Project p)
        {
            return new ProjectViewModel
            {
                ProjectId = p.ProjectId,
                Title = p.Title,
                Owner = p.Owner
            };
        }
        private BugViewModel ToBugViewModel(Bug b)
        {
            return new BugViewModel
            {
                BugId = b.BugId,
                ProjectId = b.ProjectId,
                Status = b.Status.ToString()
            };
        }
         private MessageViewModel ToMessageViewModel(Message m)
        {
            return new MessageViewModel
            {
                MessageId = m.MessageId,
                BugId = m.BugId,
                SubmissionId = m.SubmissionId,
                Text = m.Text,
                IsResolved = m.IsResolved
            };
        }
        /*----------------------------------------------*/

        //ToEntity Method
        private Project ToProjectEntity(ProjectCreateViewModel p)
        {
            return new Project
            {
                Title = p.Title,
                Owner = p.Owner
            };
        }
        private Bug ToBugEntity(BugCreateViewModel b)
        {
            return new Bug
            {
                ProjectId = b.ProjectId,
                Status = b.Status
            };
        }
        private Message ToMessageEntity(MessageCreateViewModel m)
        {
            return new Message
            {
                BugId = m.BugId,
                SubmissionId = m.SubmissionId,
                Text = m.Text,
                IsResolved = m.IsResolved
            };
        }
    }
}
