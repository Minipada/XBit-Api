using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XBitApi.Models;
using XBitApi.EF;

namespace XBitApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ShelfController : Controller
    {
        private XBitContext context;

        public ShelfController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/context
        [HttpGet]
        public IActionResult GetShelves(string name, Guid locationId)
        {
            List<Shelf> shelves = context.Shelves.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<Shelf> sToRemove = new List<Shelf>(shelves.Where(s => s.Name != name));
                foreach (var s in sToRemove)
                {
                    shelves.Remove(s);
                }
            }

            if (locationId != Guid.Empty)
            {
                List<Shelf> sToRemove = new List<Shelf>(shelves.Where(s => s.LocationId != locationId));
                foreach (var s in sToRemove)
                {
                    shelves.Remove(s);
                }
            }

            return Ok(shelves);
        }

        // GET api/shelf/000-0000-00000
        [HttpGet("{id}")]
        public IActionResult GetShelf(Guid id)
        {
            Shelf shelf = context.Shelves.Find(id);
            if (shelf == null)
                return NotFound();
            return Ok(shelf);
        }

        // POST api/shelf
        [HttpPost]
        public IActionResult PostShelf([FromBody]Shelf shelf)
        {
            if (context.Locations.Find(shelf.LocationId) == null)
                return BadRequest();

            context.Shelves.Add(shelf);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, shelf);
        }

        // PUT api/shelf
        [HttpPut]
        public IActionResult PutShelf([FromBody]Shelf shelf)
        {
            if (context.Locations.Find(shelf.LocationId) == null)
                return BadRequest();

            if (!context.Shelves.Any(s => s.Id == shelf.Id))
                return NotFound();

            context.Shelves.Update(shelf);
            context.SaveChanges();
            return Ok(shelf);
        }

        // DELETE api/shelf/000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteShelf(Guid id)
        {
            Shelf shelf = context.Shelves.Find(id);
            if (shelf == null)
                return NotFound();

            context.Shelves.Remove(shelf);
            context.SaveChanges();
            return Ok();
        }
    }
}
