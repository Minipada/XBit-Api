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
    public class MinerAlgorithmController : Controller
    {
        private XBitContext context;

        public MinerAlgorithmController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/mineralgorithm
        [HttpGet]
        public IActionResult GetMinerAlgorithms(Guid minerTypeId, Guid algorithmId, double hashrate)
        {
            try
            {
                List<MinerAlgorithm> minerAlgorithms = context.MinerAlgorithms.ToList();

                if (minerTypeId != Guid.Empty)
                {
                    List<MinerAlgorithm> maToRemove = new List<MinerAlgorithm>(minerAlgorithms.Where(ma => ma.MinerTypeId != minerTypeId));
                    foreach (var ma in maToRemove)
                    {
                        minerAlgorithms.Remove(ma);
                    }
                }

                if (algorithmId != Guid.Empty)
                {
                    List<MinerAlgorithm> maToRemove = new List<MinerAlgorithm>(minerAlgorithms.Where(ma => ma.AlgorithmId != algorithmId));
                    foreach (var ma in maToRemove)
                    {
                        minerAlgorithms.Remove(ma);
                    }
                }

                if (hashrate == 0)
                {
                    List<MinerAlgorithm> maToRemove = new List<MinerAlgorithm>(minerAlgorithms.Where(ma => ma.Hashrate != hashrate));
                    foreach (var ma in maToRemove)
                    {
                        minerAlgorithms.Remove(ma);
                    }
                }

                return Ok(minerAlgorithms);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/mineralgorithm/000-0000-0000000
        [HttpGet("{id}")]
        public IActionResult GetMinerAlgorithm(Guid id)
        {
            try
            {
                MinerAlgorithm minerAlgorithm = context.MinerAlgorithms.Find(id);
                if (minerAlgorithm == null)
                    return NotFound();
                return Ok(minerAlgorithm);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/minerAlgorithm
        public IActionResult PostMinerAlgorithm([FromBody]MinerAlgorithm minerAlgorithm)
        {
            try
            {
                if (context.MinerTypes.Find(minerAlgorithm.MinerTypeId) == null || context.Algorithms.Find(minerAlgorithm.AlgorithmId) == null)
                    return BadRequest();

                context.MinerAlgorithms.Add(minerAlgorithm);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, minerAlgorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/mineralgorithm
        [HttpPut]
        public IActionResult PutMinerAlgorithm([FromBody]MinerAlgorithm minerAlgorithm)
        {
            try
            {
                if (context.MinerTypes.Find(minerAlgorithm.MinerTypeId) == null || context.Algorithms.Find(minerAlgorithm.AlgorithmId) == null)
                    return BadRequest();

                if (!context.MinerAlgorithms.Any(ma => ma.Id == minerAlgorithm.Id))
                    return NotFound();

                context.MinerAlgorithms.Update(minerAlgorithm);
                context.SaveChanges();
                return Ok(minerAlgorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/mineralgorithm/000-0000-00000000
        [HttpDelete("{id}")]
        public IActionResult DeleteMinerAlgorithm(Guid id)
        {
            try
            {
                MinerAlgorithm minerAlgorithm = context.MinerAlgorithms.Find(id);
                if (minerAlgorithm == null)
                    return NotFound();

                context.MinerAlgorithms.Remove(minerAlgorithm);
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
