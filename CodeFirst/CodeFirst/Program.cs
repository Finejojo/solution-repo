using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Program
    {
        public  class Author
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
        
        public class PlutoContext : DbContext
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Author> Authors { get; set; }

        }
        static void Main(string[] args)
        {
        }
    }
}
