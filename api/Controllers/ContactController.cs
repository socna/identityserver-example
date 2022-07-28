using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using api.Data;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private TodoContext _context;

        public ContactController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            var contacts = _context.Contacts.ToArray();
            return contacts;
        }


        [HttpPut]
        public async Task<ActionResult> Create(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                _context.Remove(contact);
                await _context.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("{id}")]
        public Contact Info(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            
            return contact;
        }


        [HttpPost]
        public async Task<ActionResult> Update(Contact contact)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
            return Accepted();
        }
    }
}