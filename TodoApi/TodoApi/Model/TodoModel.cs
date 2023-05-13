using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Model
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public bool Completed { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
