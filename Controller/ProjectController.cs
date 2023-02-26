using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BugTracking.Services;
using BugTracking.ViewModels;
using BugTracking.Models;
using Microsoft.AspNetCore.Authorization;

namespace BugTracking.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BugTrackingController : ControllerBase
    {
        private readonly IBugTrackingService _service;
        public BugTrackingController(IBugTrackingService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> GetAllProjectAsync()
        {
            return Ok(await _service.GetAllProjectAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectViewModel>> GetProjectByIdAsync(int id)
        {
            return Ok(await _service.GetProjectByIdAsync(id));
        }
        [HttpPost("add-project")]
        public async Task<ActionResult<ProjectViewModel>> CreateProjectAsync(ProjectCreateViewModel projectModel)
        {
            return Ok(await _service.CreateProjectAsync(projectModel));
        }
        /*----------------------------------------------------------*/
        //Bugs
        [HttpGet("{projectId:int}/bugs")]
        public async Task<ActionResult<IEnumerable<BugViewModel>>> GetAllBugsInProjectAsync(int projectId)
        {
            return Ok(await _service.GetAllBugsInProjectAsync(projectId));
        }

        //Bug by Id
        [HttpGet("{projectId:int}/bugs/{bugId:int}")]
        public async Task<ActionResult<BugViewModel>> GetBugByIdAsync(int bugId)
        {
            return Ok(await _service.GetBugByIdAsync(bugId));
        }

        //bug submission
        [HttpPost("{projectId:int}/report-bug")]
        public async Task<ActionResult<BugViewModel>> CreateBugAsync(BugCreateViewModel bugModel, int projectId)
        {
            return Ok(await _service.CreateBugAsync(bugModel, projectId));
        }

        /*----------------------------------------------------------*/
        //Getting all the messages
        [HttpGet("{projectId:int}/bugs/{bugId:int}/messages")]
        public async Task<ActionResult<MessageViewModel>> GetAllMessagesInBugAsync(int bugId)
        {
            return Ok(await _service.GetAllMessagesInBugAsync(bugId));
        }

        //Get Message by Id
        [HttpGet("{projectId:int}/bugs/{bugId:int}/messages/{messageId:int}")]
        public async Task<ActionResult<MessageViewModel>> GetMessageByIdAsync(int messageId)
        {
            return Ok(await _service.GetMessageByIdAsync(messageId));
        }
        [HttpPost("{projectId:int}/bugs/{bugId:int}/add-message")]
        public async Task<ActionResult<MessageViewModel>> CreateMessageAsync(MessageCreateViewModel messageModel, int bugId)
        {
            var res = await _service.CreateMessageAsync(messageModel, bugId);
            //checking whether bug is resolved or not
            return res == null ? Ok("Bug is closed. Can't add message any more!") : Ok(res);
        }

        /*----------------------------------------------------*/
        //Dashboard
        [HttpGet("dashBoard")]
        public async Task<ActionResult<DashBoardViewModel>> GetDashBoardViewModel()
        {
            return Ok(await _service.GetDashBoardViewModel());
        }
    }
}