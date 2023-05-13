using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Model
{
    public class AddTodoModel
    {
        
        public string Task { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Completed { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
