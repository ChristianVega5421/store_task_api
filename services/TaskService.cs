using System;
using TaskAdministratorAPI.iservices;
using TaskAdministratorAPI.models;
using TaskAdministratorAPI.models.enums;
using TaskAdministratorAPI.repositories;
using TaskAdministratorAPI.repositories.models;

namespace TaskAdministratorAPI.services
{
    public class TaskService(TaskRepository repository) : ITaskService
    {
        public bool CompleteTask(int ID)
        {
            return UpdateTaskStatus(ID, (int)Enums.TaskStatus.Completed);
        }

        public int CreateTask(TaskModel task)
        {
            TaskDBModel taskDBModel = ToTaskDBModel(task);
            repository.Add(taskDBModel);
            if (repository.SaveChanges() > 0)
            {
                return taskDBModel.Id;
            }
            return 0;
        }

        public bool DeleteTask(int ID)
        {
            return UpdateTaskStatus(ID, (int)Enums.TaskStatus.Deleted);
        }

        public IReadOnlyCollection<TaskModel> GetTasks()
        {
            return repository.Tasks.Where(x => x.Status == (int)Enums.TaskStatus.Active).OrderBy(x => x.Id).Select(dbTask => new TaskModel()
            {
                Id = dbTask.Id,
                Name = dbTask.Name,
                UpdateDate = dbTask.UpdateDate,
                CreationDate = dbTask.CreationDate,
                Description = dbTask.Description,
                Status = dbTask.Status,
            }).ToList();
        }

        public IReadOnlyCollection<TaskModel> GetTasksByStatus(Enums.TaskStatus status)
        {
            return repository.Tasks.Where(t => t.Status == (int)status).Select(dbTask => new TaskModel()
            {
                Id = dbTask.Id,
                Name = dbTask.Name,
                UpdateDate = dbTask.UpdateDate,
                CreationDate = dbTask.CreationDate,
                Description = dbTask.Description,
                Status = dbTask.Status,
            }).ToList();
        }

        public bool UpdateTask(TaskModel task)
        {
            var taskToUpdate = repository.Tasks.Where(t => t.Id == task.Id).FirstOrDefault();
            if (taskToUpdate != null)
            {
                taskToUpdate = MapTaskDBModel(task, taskToUpdate);
            }
            return repository.SaveChanges() > 0;
        }

        private bool UpdateTaskStatus(int ID, int status)
        {
            var task = repository.Tasks.Where(dbTask => dbTask.Id == ID).FirstOrDefault();
            if (task == null)
            {
                return false;
            }
            task.Status = status;
            task.UpdateDate = DateTime.Now;
            return repository.SaveChanges() > 0;
        }

        private TaskDBModel MapTaskDBModel(TaskModel from, TaskDBModel to)
        {
            to.Description = from.Description;
            to.UpdateDate = DateTime.Now;
            return to;
        }

        private static TaskDBModel ToTaskDBModel(TaskModel task)
        {
            return new TaskDBModel()
            {
                Name = task.Name,
                Description = task.Description,
                Status = (int)Enums.TaskStatus.Active,
                CreationDate = DateTime.Now,
            };
        }
    }
}
