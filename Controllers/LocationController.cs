using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XBitApi.Models;
using XBitApi.EF;

namespace XBitApi.Controllers
{
    [Controller]
    [Route("api/[contoller]")]
    public class LocationController : Controller
    {
        private XBitContext context;

        public LocationController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/location
        [HttpGet]
        public IActionResult GetLocations(string name, Guid addressId)
        {
            List<Location> locations = context.Locations.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<Location> loToRemove = new List<Location>(locations.Where(lo => lo.Name != name));
                foreach (var lo in loToRemove)
                {
                    locations.Remove(lo);
                }
            }

            if (addressId != Guid.Empty)
            {
                List<Location> loToRemove = new List<Location>(locations.Where(lo => lo.AddressId != addressId));
                foreach (var lo in loToRemove)
                {
                    locations.Remove(lo);
                }
            }

            return Ok(locations);
        }

        // GET api/location/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetLocation(Guid id)
        {
            Location location = context.Locations.Find(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }

        // POST api/location
        [HttpPost]
        public IActionResult PostLocation([FromBody]Location location)
        {
            if (context.Addresses.Find(location.AddressId) == null)
                return BadRequest();

            context.Locations.Add(location);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, location);
        }

        // PUT api/location
        [HttpPut]
        public IActionResult PutLocation([FromBody]Location location)
        {
            if (context.Addresses.Find(location.AddressId) == null)
                return BadRequest();

            if (!context.Locations.Any(lo => lo.Id == location.Id))
                return NotFound();

            context.Locations.Update(location);
            context.SaveChanges();
            return Ok(location);
        }

        // DELETE api/location/0000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            Location location = context.Locations.Find(id);
            if (location == null)
                return NotFound();
            context.Locations.Remove(location);
            context.SaveChanges();
            return Ok();
        }
    }
}
