﻿using System;
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
        public IActionResult GetCountries(string name)
        {
            List<Country> countries = context.Countries.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<Country> countriesWithoutName = new List<Country>(countries.Where(country => country.Name != name));
                foreach (Country country in countriesWithoutName)
                {
                    countries.Remove(country);
                }
            }

            return Ok(countries);

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
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, country);
        }

        // PUT api/country
        [HttpPut]
        public IActionResult PutCountry([FromBody]Country country)
        {
            if (context.Countries.Any(co => co.Id == country.Id))
            {
                context.Countries.Update(country);
                context.SaveChanges();
                return Ok(country);
            }
            return NotFound();
        }

        // DELETE api/country/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(Guid id)
        {
            Country countryToRemove = context.Countries.Find(id);
            if (countryToRemove != null)
            {
                context.Countries.Remove(countryToRemove);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
