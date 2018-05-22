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
            try
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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/location/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetLocation(Guid id)
        {
            try
            {
                Location location = context.Locations.Find(id);
                if (location == null)
                    return NotFound();
                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/location
        [HttpPost]
        public IActionResult PostLocation([FromBody]Location location)
        {
            try
            {
                if (context.Addresses.Find(location.AddressId) == null)
                    return BadRequest();

                context.Locations.Add(location);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, location);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/location
        [HttpPut]
        public IActionResult PutLocation([FromBody]Location location)
        {
            try
            {
                if (context.Addresses.Find(location.AddressId) == null)
                    return BadRequest();

                if (!context.Locations.Any(lo => lo.Id == location.Id))
                    return NotFound();

                context.Locations.Update(location);
                context.SaveChanges();
                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/location/0000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            try
            {
                Location location = context.Locations.Find(id);
                if (location == null)
                    return NotFound();
                context.Locations.Remove(location);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
