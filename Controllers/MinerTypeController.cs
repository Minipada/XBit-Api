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
    public class MinerTypeController : Controller
    {
        private XBitContext context;

        public MinerTypeController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/minertype
        [HttpGet]
        public IActionResult GetMinerTypes(string name, Guid manufacturerId)
        {
            List<MinerType> minerTypes = context.MinerTypes.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<MinerType> mtToRemove = new List<MinerType>(minerTypes.Where(mt => mt.Name != name));
                foreach (var mt in mtToRemove)
                {
                    minerTypes.Remove(mt);
                }
            }

            if (manufacturerId != Guid.Empty)
            {
                List<MinerType> mtToRemove = new List<MinerType>(minerTypes.Where(mt => mt.ManufacturerId != manufacturerId));
                foreach (var mt in mtToRemove)
                {
                    minerTypes.Remove(mt);
                }
            }

            return Ok(minerTypes);
        }

        // GET api/minertype/000-0000-000000
        [HttpGet("{id}")]
        public IActionResult GetMinerTypes(Guid id)
        {
            MinerType minerType = context.MinerTypes.Find(id);
            if (minerType == null)
                return NotFound();

            return Ok(minerType);
        }

        // POST api/minertype
        [HttpPost]
        public IActionResult PostMinerType([FromBody]MinerType minerType)
        {
            if (context.Manufacturers.Find(minerType.ManufacturerId) == null)
                return BadRequest();

            context.MinerTypes.Add(minerType);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, minerType);
        }

        // PUT api/minertype
        [HttpPut]
        public IActionResult PutMinerType([FromBody]MinerType minerType)
        {
            if (context.Manufacturers.Find(minerType.ManufacturerId) == null)
                return BadRequest();

            if (!context.MinerTypes.Any(mt => mt.Id == minerType.Id))
                return NotFound();

            context.MinerTypes.Update(minerType);
            context.SaveChanges();
            return Ok(minerType);
        }

        // DELETE api/minertype/000-0000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteMinerType(Guid id)
        {
            MinerType minerType = context.MinerTypes.Find(id);
            if (minerType == null)
                return NotFound();

            context.MinerTypes.Remove(minerType);
            context.SaveChanges();
            return Ok();
        }
    }
}
