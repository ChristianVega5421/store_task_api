namespace TaskAdministratorAPI.Controllers.models
{
    public class ControllerTaskModel
    {
        private string name;
        private string description;

        public ControllerTaskModel(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }

    public class DescriptionPatch
    {
        private string description;

        public DescriptionPatch(string description)
        {
            this.description = description;
        }
        public string Description { get => description; set { description = value; } }
    }

    public class TaskStatusChange
    {
        private int status;

        public TaskStatusChange(int status)
        {
            this.status = status;
        }

        public int Status { get => status; set => status = value; }
    }
}
