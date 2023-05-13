namespace WebAPI.Model
{
    public class AddContact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
