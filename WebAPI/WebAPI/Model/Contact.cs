namespace WebAPI.Model
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
