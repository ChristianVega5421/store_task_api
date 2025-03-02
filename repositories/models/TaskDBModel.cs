using Microsoft.EntityFrameworkCore;
using TaskAdministratorAPI.utils;

namespace TaskAdministratorAPI.repositories.models
{
    public class TaskDBModel
    {
        private int id;
        private string name;
        private string description;
        private DateTime creationDate;
        private DateTime? updatedDate;
        private int status;



        public TaskDBModel(string name, string description, DateTime creationDate, DateTime? updateDate, int status)
        {
            this.name = name;
            this.description = description;
            this.creationDate = creationDate;
            this.updatedDate = updateDate;
            this.status = status;
        }

        public TaskDBModel() { }

        public TaskDBModel GetClone()
        {
            return Extension.Clone(this);
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public DateTime? UpdateDate { get => updatedDate; set => updatedDate = value; }
        public int Status { get => status; set => status = value; }
    }
}
