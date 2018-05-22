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
    public class FarmMemberController : Controller
    {
        private XBitContext context;

        public FarmMemberController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/farmmember
        [HttpGet]
        public IActionResult GetFarmMembers(Guid customerId, Guid miningFarmId, Guid farmRightId)
        {
            try
            {
                List<FarmMember> farmMembers = context.FarmMembers.ToList();

                if (customerId != Guid.Empty)
                {
                    List<FarmMember> farmMembersToRemove = new List<FarmMember>(farmMembers.Where(fm => fm.CustomerId != customerId));
                    foreach (var fm in farmMembersToRemove)
                    {
                        farmMembers.Remove(fm);
                    }
                }

                if (miningFarmId != Guid.Empty)
                {
                    List<FarmMember> farmMembersToRemove = new List<FarmMember>(farmMembers.Where(fm => fm.MiningFarmId != miningFarmId));
                    foreach (var fm in farmMembersToRemove)
                    {
                        farmMembers.Remove(fm);
                    }
                }

                if (farmRightId != Guid.Empty)
                {
                    List<FarmMember> farmMembersToRemove = new List<FarmMember>(farmMembers.Where(fm => fm.FarmRightId != farmRightId));
                    foreach (var fm in farmMembersToRemove)
                    {
                        farmMembers.Remove(fm);
                    }
                }

                return Ok(farmMembers);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/farmmember/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetFarmMember(Guid id)
        {
            try
            {
                FarmMember farmMember = context.FarmMembers.Find(id);
                if (farmMember == null)
                    return NotFound();
                return Ok(farmMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/farmmember
        [HttpPost]
        public IActionResult PostFarmMember([FromBody]FarmMember farmMember)
        {
            try
            {
                if (context.FarmRights.Find(farmMember.FarmRightId) == null || context.Customers.Find(farmMember.CustomerId) == null || context.MiningFarms.Find(farmMember.MiningFarmId) == null)
                    return BadRequest();

                context.FarmMembers.Add(farmMember);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, farmMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/farmmember
        [HttpPut]
        public IActionResult PutFarmMember([FromBody]FarmMember farmMember)
        {
            try
            {
                if (context.FarmRights.Find(farmMember.FarmRightId) == null || context.Customers.Find(farmMember.CustomerId) == null || context.MiningFarms.Find(farmMember.MiningFarmId) == null)
                    return BadRequest();

                if (!context.FarmMembers.Any(fm => fm.Id == farmMember.Id))
                    return NotFound();

                context.FarmMembers.Update(farmMember);
                context.SaveChanges();
                return Ok(farmMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/farmmember/000-000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteFarmMember(Guid id)
        {
            try
            {
                FarmMember farmMember = context.FarmMembers.Find(id);
                if (farmMember == null)
                    return NotFound();
                context.FarmMembers.Remove(farmMember);
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
