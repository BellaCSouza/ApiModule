using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModule.Context;
using ApiModule.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly PhonebookContext _context;

        public ContactController(PhonebookContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact) {
            _context.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var contact = _context.Contacts.Find(id);
            
            if (contact == null) {
                return NotFound();
            } else {
               return Ok(contact); 
            }
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name) {
            var contacts = _context.Contacts.Where(x => x.Name.Contains(name));
            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact) {
            var contactDB = _context.Contacts.Find(id);

            if (contactDB == null) {
                return NotFound();
            }

            contactDB.Name = contact.Name;
            contactDB.PhoneNumber = contact.PhoneNumber;
            contactDB.Active = contact.Active;

            _context.Contacts.Update(contactDB);
            _context.SaveChanges();

            return Ok(contactDB);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var contactDB = _context.Contacts.Find(id);

            if (contactDB == null) {
                return NotFound();
            }

            _context.Contacts.Remove(contactDB);
            _context.SaveChanges();
            return NoContent();
        }

        
    }
}