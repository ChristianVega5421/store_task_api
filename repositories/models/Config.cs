namespace TaskAdministratorAPI.repositories.models
{
    public class Config
    {
        public const string section = "DB";

        public string Path { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }
}
