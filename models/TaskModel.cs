using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace TaskAdministratorAPI.models
{
    public class TaskModel
    {
        private int id;
        private string? name;
        private string? description;
        private DateTime creationDate;
        private DateTime? updatedDate;
        private int status;

        [JsonConstructor]
        public TaskModel(int _id, string name, string description, DateTime creationDate, DateTime? updateDate = null, int status = 1)
        {
            this.id = _id;
            this.name = name;
            this.description = description;
            this.creationDate = creationDate;
            this.updatedDate = updateDate;
            this.status = status;
        }

        public TaskModel(string name, string description, DateTime creationDate, DateTime? updateDate, int status)
        {
            this.name = name;
            this.description = description;
            this.creationDate = creationDate;
            this.updatedDate = updateDate;
            this.status = status;
        }

        public TaskModel() { }

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Description { get => description; set => description = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public DateTime? UpdateDate { get => updatedDate; set => updatedDate = value; }
        public int Status { get => status; set => status = value; }
    }
}
