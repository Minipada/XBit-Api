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
        private LoggingService loggingService;

        public AddressController(XBitContext context)
        {
            this.context = context;
            this.loggingService = new LoggingService(context);
        }

        // GET api/address?countryId=test
        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(context.Addresses.ToList());
        }

        // GET api/address/Guid
        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            Address address = context.Addresses.Find(id);
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
            context.Addresses.Add(address);
            context.SaveChanges();
            return CreatedAtAction(address.Id.ToString(), address);
        }

        // PUT api/address
        [HttpPut]
        public IActionResult PutAddress([FromBody]Address address)
        {
            context.Addresses.Update(address);
            context.SaveChanges();
            return Ok(address);
        }

        // DELETE api/address/Guid
        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(Guid id)
        {
            context.Addresses.Remove(context.Addresses.Find(id));
            context.SaveChanges();
            return Ok();
        }
    }
}
