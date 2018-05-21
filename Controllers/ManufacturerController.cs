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
    public class ManufacturerController : Controller
    {
        private XBitContext context;

        public ManufacturerController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/manufacturer
        [HttpGet]
        public IActionResult GetManufacturers(string name, string phone, string email, string website)
        {
            List<Manufacturer> manufacturers = context.Manufacturers.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<Manufacturer> maToRemove = new List<Manufacturer>(manufacturers.Where(ma => ma.Name != name));
                foreach (var ma in maToRemove)
                {
                    manufacturers.Remove(ma);
                }
            }

            if (!String.IsNullOrEmpty(email))
            {
                List<Manufacturer> maToRemove = new List<Manufacturer>(manufacturers.Where(ma => ma.Email != email));
                foreach (var ma in maToRemove)
                {
                    manufacturers.Remove(ma);
                }
            }

            if (!String.IsNullOrEmpty(phone))
            {
                List<Manufacturer> maToRemove = new List<Manufacturer>(manufacturers.Where(ma => ma.Phone != phone));
                foreach (var ma in maToRemove)
                {
                    manufacturers.Remove(ma);
                }
            }

            if (!String.IsNullOrEmpty(website))
            {
                List<Manufacturer> maToRemove = new List<Manufacturer>(manufacturers.Where(ma => ma.Website != website));
                foreach (var ma in maToRemove)
                {
                    manufacturers.Remove(ma);
                }
            }

            return Ok(manufacturers);
        }

        // GET api/manufacturer/000-000-000000
        [HttpGet("{id}")]
        public IActionResult GetManufacturer(Guid id)
        {
            Manufacturer manufacturer = context.Manufacturers.Find(id);
            if (manufacturer == null)
                return NotFound();
            return Ok(manufacturer);
        }

        // POST api/manufacturer
        [HttpPost]
        public IActionResult PostManufacturer([FromBody]Manufacturer manufacturer)
        {
            context.Manufacturers.Add(manufacturer);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, manufacturer);
        }

        // PUT api/manufacturer
        [HttpPut]
        public IActionResult PutManufacturer([FromBody]Manufacturer manufacturer)
        {
            if (!context.Manufacturers.Any(ma => ma.Id == manufacturer.Id))
                return NotFound();
            context.Manufacturers.Update(manufacturer);
            context.SaveChanges();
            return Ok(manufacturer);
        }

        // DELETE api/manufacturer/0000-000000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteManufacturer(Guid id)
        {
            Manufacturer manufacturer = context.Manufacturers.Find(id);
            if (manufacturer == null)
                return NotFound();
            context.Manufacturers.Remove(manufacturer);
            context.SaveChanges();
            return Ok();
        }
    }
}
