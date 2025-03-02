using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskAdministratorAPI.Controllers.models;
using TaskAdministratorAPI.iservices;
using TaskAdministratorAPI.models;
using TaskAdministratorAPI.models.enums;

namespace TaskAdministratorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService ITaskService)
        {
            _logger = logger;
            _taskService = ITaskService;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<TaskModel> GetTasks([FromQuery] int status = 9999)
        {
            if (status != 9999)
            {
                return _taskService.GetTasksByStatus((Enums.TaskStatus)status);
            }
            return _taskService.GetTasks();
        }

        [HttpPost(Name = "CreateTask")]
        public ActionResult CreateTask([FromBody] ControllerTaskModel task)
        {
            _logger.LogInformation("this is working");
            TaskModel model = new()
            {
                Name = task.Name,
                Description = task.Description,
            };
            int taskID = _taskService.CreateTask(model);
            if (taskID == 0)
            {
                _logger.LogError("error saving entity name: {name}", task.Name);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            _logger.LogInformation("object created ID: {id}" + taskID);
            return CreatedAtAction("CreateTask", new { Id = taskID }, task);
        }

        [HttpPut("{taskID}", Name = "UpdateTask")]
        public ActionResult UpdateTask([FromRoute] int taskID, [FromBody] DescriptionPatch description)
        {
            TaskModel model = new()
            {
                Id = taskID,
                Description = description.Description,
            };
            if (_taskService.UpdateTask(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{taskID}", Name = "ChangeTaskStatus")]
        public ActionResult UpdateTaskStatus([FromRoute] int taskID, [FromBody] TaskStatusChange status)
        {
            if (status.Status == (int)Enums.TaskStatus.Completed)
            {
                if (_taskService.CompleteTask(taskID))
                {
                    return Ok();
                }
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{taskID}", Name = "DeleteTask")]
        public ActionResult DeleteTask([FromRoute] int taskID)
        {
            if (_taskService.DeleteTask(taskID))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
