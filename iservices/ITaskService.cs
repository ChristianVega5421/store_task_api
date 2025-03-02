using System;
using TaskAdministratorAPI.models;
using TaskAdministratorAPI.models.enums;

namespace TaskAdministratorAPI.iservices
{
    public interface ITaskService
    {
        IReadOnlyCollection<TaskModel> GetTasks();

        IReadOnlyCollection<TaskModel> GetTasksByStatus(Enums.TaskStatus status);

        int CreateTask(TaskModel task);

        bool UpdateTask(TaskModel task);

        bool CompleteTask(int ID);

        bool DeleteTask(int ID);
    }
}
