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
    public class HostingPeriodController : Controller
    {
        private XBitContext context;

        public HostingPeriodController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/hostingperiod
        public IActionResult GetHostingPeriods(DateTime startDate, DateTime endDate, Guid minerId, double pricePerMonth)
        {
            List<HostingPeriod> hostingPeriods = context.HostingPeriods.ToList();

            if (startDate != null)
            {
                List<HostingPeriod> hpToRemove = new List<HostingPeriod>(hostingPeriods.Where(hp => hp.StartDate != startDate));
                foreach (var hp in hpToRemove)
                {
                    hostingPeriods.Remove(hp);
                }
            }

            if (endDate != null)
            {
                List<HostingPeriod> hpToRemove = new List<HostingPeriod>(hostingPeriods.Where(hp => hp.EndDate != endDate));
                foreach (var hp in hpToRemove)
                {
                    hostingPeriods.Remove(hp);
                }
            }

            if (minerId != Guid.Empty)
            {
                List<HostingPeriod> hpToRemove = new List<HostingPeriod>(hostingPeriods.Where(hp => hp.MinerId != minerId));
                foreach (var hp in hpToRemove)
                {
                    hostingPeriods.Remove(hp);
                }
            }

            if (pricePerMonth != 0)
            {
                List<HostingPeriod> hpToRemove = new List<HostingPeriod>(hostingPeriods.Where(hp => hp.PricePerMonth != pricePerMonth));
                foreach (var hp in hpToRemove)
                {
                    hostingPeriods.Remove(hp);
                }
            }

            return Ok(hostingPeriods);
        }

        // GET api/hostingperiod/000-0000-000000
        [HttpGet("{id}")]
        public IActionResult GetHostingPeriod(Guid id)
        {
            HostingPeriod hostingPeriod = context.HostingPeriods.Find(id);
            if (hostingPeriod == null)
                return NotFound();
            return Ok(hostingPeriod);
        }

        // POST api/hostingPeriod
        [HttpPost]
        public IActionResult PostHostingPeriod([FromBody]HostingPeriod hostingPeriod)
        {
            if (context.Miners.Find(hostingPeriod.Id) == null)
                return BadRequest();

            context.HostingPeriods.Add(hostingPeriod);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, hostingPeriod);
        }

        // PUT api/hostingPeriod
        [HttpPut]
        public IActionResult PutHostingPeriod([FromBody]HostingPeriod hostingPeriod)
        {
            if (context.Miners.Find(hostingPeriod.Id) == null)
                return BadRequest();

            if (!context.HostingPeriods.Any(hp => hp.Id == hostingPeriod.Id))
                return NotFound();

            context.HostingPeriods.Update(hostingPeriod);
            context.SaveChanges();
            return Ok(hostingPeriod);
        }

        // DELETE api/hostingperiod/0000-0000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteHostingPeriod(Guid id)
        {
            HostingPeriod hostingPeriod = context.HostingPeriods.Find(id);
            if (hostingPeriod == null)
                return NotFound();
            return Ok(hostingPeriod);
        }
    }
}
