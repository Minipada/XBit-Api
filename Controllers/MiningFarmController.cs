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
    public class MiningFarmController : Controller
    {
        private XBitContext context;

        public MiningFarmController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/miningfarm
        [HttpGet]
        public IActionResult GetMiningFarms(string name, Guid adminCustomerId)
        {
            List<MiningFarm> miningFarms = context.MiningFarms.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<MiningFarm> mfToRemove = new List<MiningFarm>(miningFarms.Where(mf => mf.Name != name));
                foreach (var mf in mfToRemove)
                {
                    miningFarms.Remove(mf);
                }
            }

            if (adminCustomerId != Guid.Empty)
            {
                List<MiningFarm> mfToRemove = new List<MiningFarm>(miningFarms.Where(mf => mf.AdminCustomerId != adminCustomerId));
                foreach (var mf in mfToRemove)
                {
                    miningFarms.Remove(mf);
                }
            }

            return Ok(miningFarms);
        }

        // GET api/miningfarm/0000-0000-00000
        [HttpGet("{id}")]
        public IActionResult GetMiningFarm(Guid id)
        {
            MiningFarm miningFarm = context.MiningFarms.Find(id);
            if (miningFarm == null)
                return NotFound();
            return Ok(miningFarm);
        }

        // POST api/miningfarm
        [HttpPost]
        public IActionResult PostMiningFarm([FromBody]MiningFarm miningFarm)
        {
            if (context.Customers.Find(miningFarm.AdminCustomerId) == null)
                return BadRequest();

            context.MiningFarms.Add(miningFarm);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, miningFarm);
        }

        // PUT api/miningFarm
        [HttpPut]
        public IActionResult PutMiningFarm([FromBody]MiningFarm miningFarm)
        {
            if (context.Customers.Find(miningFarm.AdminCustomerId) == null)
                return BadRequest();

            if (!context.MiningFarms.Any(mf => mf.Id == miningFarm.Id))
                return NotFound();

            context.MiningFarms.Update(miningFarm);
            context.SaveChanges();
            return Ok(miningFarm);
        }

        // DELETE api/miningfarm/000-0000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteMiningFarm(Guid id)
        {
            MiningFarm miningFarm = context.MiningFarms.Find(id);
            if (miningFarm == null)
                return NotFound();
            context.MiningFarms.Remove(miningFarm);
            context.SaveChanges();
            return Ok();
        }
    }
}
