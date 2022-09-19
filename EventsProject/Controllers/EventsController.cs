using EventsProject.Dtos;
using EventsProject.Model;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    [Authorize]
    public class EventsController : Controller
    {
        private EventsContext context;

        public EventsController(EventsContext context)
        { 
            this.context = context;
        }        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get() => await context.Events.ProjectToType<EventDto>().ToListAsync();


        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> Get(int id)
        { 
            var ev = await context.Events.Where(e => e.Id == id).ProjectToType<EventDto>().FirstOrDefaultAsync();
            if (ev == null)
            {
                return NotFound();
            }

            return new ActionResult<EventDto>(ev);
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> Post(EventDto _event)
        {
            if (_event == null)
            {
                return BadRequest();
            }

            context.Events.Add(_event.ToEntity());
            await context.SaveChangesAsync();
            return Ok(_event);
        }

        [HttpPut]
        public async Task<ActionResult<EventDto>> Put(EventDto _event)
        {
            if (_event == null)
            {
                return BadRequest();
            }

            var ev = _event.ToEntity();

            if (!context.Events.Any(e => e.Id == ev.Id))
            {
                return NotFound();
            }

            context.Update(ev);
            await context.SaveChangesAsync();

            return Ok(_event);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EventDto>> Delete(int id)
        { 
            var _event = context.Events.FirstOrDefault(e => e.Id == id);

            if (_event == null)
            {
                return BadRequest();
            }

            context.Remove(_event);
            await context.SaveChangesAsync();
            var eventResult = EventDto.FromEntity(_event);

            return Ok(eventResult);
        }
    }
}
