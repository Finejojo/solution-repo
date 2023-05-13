namespace ASPNETMVCCORE.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DaeteOFBirth { get; set; }
        public Double Salary { get; set; }
        public String Department { get; set; }
    }
}
