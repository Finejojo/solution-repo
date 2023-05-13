using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace NewPluto
{
    public class Program
    {
        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual IList<Course> Courses { get; set; }
        }
        public partial class Course
        {
            public int Id { get; set; }

            public string Title { get; set; }
            public string Description { get; set; }
            public CourseLevel Level { get; set; }
            public short FullPrice { get; set; }

            public virtual Author Author { get; set; }
            public virtual IList<Tag> Tags { get; set; }
        }

        public partial class Tag
        {

            public int Id { get; set; }
            public string Name { get; set; }

            public virtual IList<Course> Courses { get; set; }
        }

        public enum CourseLevel : byte
        {
            Beginner = 1,
            Intermediate = 2,
            Advance = 3
        }

        public class PlutoContext : System.Data.Entity.DbContext
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Author> Authors { get; set; }

            public PlutoContext()
                : base("name:DefaultConnection")
            { }
        }
        static void Main(string[] args)
        {
        }
    }
}
