using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ApiDbContext dbContext;

        public ContactController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContact addContact)
        {
            if (addContact != null)
            {
                var contact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = addContact.Name,
                    Email = addContact.Email,
                    CreatedDate = DateTime.Now,
                    PhoneNo = addContact.PhoneNo,
                    Address = addContact.Address,
                };
                await dbContext.Contacts.AddAsync(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact(Guid id, AddContact contact)
        {
            var cont = await dbContext.Contacts.FindAsync(id);
            if(cont != null)
            {
                cont.Name = contact.Name;
                cont.Email = contact.Email;
                cont.PhoneNo = contact.PhoneNo;
                cont.Address = contact.Address;

                await dbContext.SaveChangesAsync();

                return Ok(cont);

            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var cont = await dbContext.Contacts.FindAsync(id);
            if (cont != null)
            {
                dbContext.Contacts.Remove(cont);
                await dbContext.SaveChangesAsync();

                return Ok(cont);
            }

            return NotFound();
        }
    }
}
