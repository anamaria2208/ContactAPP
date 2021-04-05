using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactApp.DAL;
using ContactApp.Models;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        //return 200 OK
        //response: body JSON

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.Where(x=> x.IsActive == true).ToListAsync();
        }

        // GET: api/Contacts/5
        //return 200 OK
        //response: body JSON

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound(new { Message =  "Contact was not found" });
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // 204 No Content if successful

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {

            var dbContact = await _context.Contacts.FindAsync(id);

            if (dbContact == null)
            {
                return NotFound(new { Message = "Contact was not found" });
            }

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.MobilePhone = contact.MobilePhone;
            dbContact.Email = contact.Email;
            dbContact.Address = contact.Address;
            dbContact.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();

            
            return NoContent();
        }

        // POST: api/Contacts
        //return HTTP 201 if successful
        // return 200 OK
        //response: body JSON object that was created

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        // DELETE: api/Contacts/5
        //204 No Content if successful

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact was not found" });
            }

            contact.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
