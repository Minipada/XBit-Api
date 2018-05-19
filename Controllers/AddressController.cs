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
    public class AddressController : Controller
    {
        private XBitContext context;

        public AddressController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/address?countryId=test
        [HttpGet]
        public IActionResult GetAddresses(string street, string place, string zip, Guid countryId)
        {
            List<Address> addresses = context.Addresses.ToList();

            if (!String.IsNullOrEmpty(street))
            {
                List<Address> addressesToRemove = new List<Address>(addresses.Where(add => add.Street != street));
                foreach (Address address in addressesToRemove)
                {
                    addresses.Remove(address);
                }
            }

            if (!String.IsNullOrEmpty(place))
            {
                List<Address> addressesToRemove = new List<Address>(addresses.Where(add => add.Place != place));
                foreach (Address address in addressesToRemove)
                {
                    addresses.Remove(address);
                }
            }

            if (!String.IsNullOrEmpty(zip))
            {
                List<Address> addressesToRemove = new List<Address>(addresses.Where(add => add.Zip != zip));
                foreach (Address address in addressesToRemove)
                {
                    addresses.Remove(address);
                }
            }

            if (countryId != Guid.Empty)
            {
                List<Address> addressesToRemove = new List<Address>(addresses.Where(add => add.CountryId != countryId));
                foreach (Address address in addressesToRemove)
                {
                    addresses.Remove(address);
                }
            }

            return Ok(addresses);
        }

        // GET api/address/Guid
        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            Address address = context.Addresses.Find(id);
            var countries = context.Countries.ToList();
            var country = address.Country;
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        // POST api/address
        [HttpPost]
        public IActionResult PostAddress([FromBody]Address address)
        {
            if (context.Countries.Find(address.CountryId) != null)
            {
                context.Addresses.Add(address);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, address);
            }
            return BadRequest();
        }

        // PUT api/address
        [HttpPut]
        public IActionResult PutAddress([FromBody]Address address)
        {
            if (context.Countries.Find(address.CountryId) == null)
                return BadRequest();
            if (context.Addresses.Any(addr => addr.Id == address.Id))
            {
                context.Addresses.Update(address);
                context.SaveChanges();
                return Ok(address);
            }
            return NotFound();
        }

        // DELETE api/address/Guid
        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(Guid id)
        {
            Address addressToRemove = context.Addresses.Find(id);
            if (addressToRemove != null)
            {
                context.Addresses.Remove(addressToRemove);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
