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
    public class CountryController : Controller
    {
        private XBitContext context;

        public CountryController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/country
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(context.Countries.ToList());
        }

        // GET api/country/Guid
        [HttpGet("{id}")]
        public IActionResult GetCountry(Guid id)
        {
            Country country = context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST api/country
        [HttpPost]
        public IActionResult PostCountry([FromBody]Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
            return CreatedAtAction(country.Id.ToString(), country);
        }

        // PUT api/country
        [HttpPut]
        public IActionResult PutCountry([FromBody]Country country)
        {
            context.Countries.Update(country);
            context.SaveChanges();
            return Ok(country);
        }

        // DELETE api/country/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(Guid id)
        {
            context.Countries.Remove(context.Countries.Find(id));
            return Ok();
        }
    }
}
