﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingEventApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExistingEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistingEventsController : ControllerBase
    {
        private readonly ExistingEventContext context;

        public ExistingEventsController(ExistingEventContext context)
        {
            this.context = context;
        }

        // GET: api/ExistingEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExistingEvent>>> GetExistingEvents()
        {
            return await context.ExistingEvents.ToListAsync();
        }

        // GET: api/ExistingEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExistingEvent>> GetTodoItem(long id)
        {
            var todoItem = await context.ExistingEvents.FindAsync(id);
            if (todoItem == null)
                return NotFound();
            return todoItem;
        }

        // PUT: api/ExistingEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, [FromBody]string name)
        {
            var modifiedEvent = context.ExistingEvents.Find(id);
            if (modifiedEvent == null)
                return BadRequest();
            modifiedEvent.Name = name;
            context.Entry(modifiedEvent).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // POST: api/ExistingEvents
        [HttpPost]
        public async Task<ActionResult<ExistingEvent>> PostTodoItem([FromBody]string name)
        {
            var existingEvent = new ExistingEvent(name);
            context.ExistingEvents.Add(existingEvent);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = existingEvent.Id }, 
                existingEvent);
        }

        // DELETE: api/ExistingEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var existingEvent = await context.ExistingEvents.FindAsync(id);
            if (existingEvent == null)
                return NotFound();
            context.ExistingEvents.Remove(existingEvent);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return context.ExistingEvents.Any(e => e.Id == id);
        }
    }
}
