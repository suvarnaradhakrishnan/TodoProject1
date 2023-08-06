namespace TodoProject.Models
{
    public class Todos
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime completedOn { get; set;}

    }
}
