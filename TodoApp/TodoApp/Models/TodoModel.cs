using System;

using System.ComponentModel.DataAnnotations;

using System.Web;

namespace TodoApp.Models
{
    public class TodoModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Task { get; set; }

        [Required]
        public string Priority { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
