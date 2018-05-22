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
    public class FarmRightController : Controller
    {
        private XBitContext context;

        public FarmRightController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/farmright
        [HttpGet]
        public IActionResult GetFarmRights(bool? canSwitchCoins, bool? canBuyMiningPackages, bool? canWithdrawCoins, bool? hasReadRights)
        {
            try
            {
                List<FarmRight> farmRights = context.FarmRights.ToList();

                if (canSwitchCoins != null)
                {
                    List<FarmRight> frToRemove = new List<FarmRight>(farmRights.Where(fr => fr.CanSwitchCoins != canSwitchCoins));
                    foreach (var fr in frToRemove)
                    {
                        farmRights.Remove(fr);
                    }
                }

                if (canBuyMiningPackages != null)
                {
                    List<FarmRight> frToRemove = new List<FarmRight>(farmRights.Where(fr => fr.CanBuyMiningPackages != canBuyMiningPackages));
                    foreach (var fr in frToRemove)
                    {
                        farmRights.Remove(fr);
                    }
                }

                if (canWithdrawCoins != null)
                {
                    List<FarmRight> frToRemove = new List<FarmRight>(farmRights.Where(fr => fr.CanWithdrawCoins != canWithdrawCoins));
                    foreach (var fr in frToRemove)
                    {
                        farmRights.Remove(fr);
                    }
                }

                if (hasReadRights != null)
                {
                    List<FarmRight> frToRemove = new List<FarmRight>(farmRights.Where(fr => fr.HasReadRights != hasReadRights));
                    foreach (var fr in frToRemove)
                    {
                        farmRights.Remove(fr);
                    }
                }

                return Ok(farmRights);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/farmright/000-0000-000000
        [HttpGet("{id}")]
        public IActionResult GetFarmRight(Guid id)
        {
            try
            {
                FarmRight farmRight = context.FarmRights.Find(id);
                if (farmRight == null)
                    return NotFound();
                return Ok(farmRight);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/farmright
        [HttpPost]
        public IActionResult PostFarmRight([FromBody]FarmRight farmRight)
        {
            try
            {
                context.FarmRights.Add(farmRight);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, farmRight);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/farmright
        [HttpPost]
        public IActionResult PutFarmRight([FromBody]FarmRight farmRight)
        {
            try
            {
                if (!context.FarmRights.Any(fr => fr.Id == farmRight.Id))
                    return NotFound();

                context.FarmRights.Update(farmRight);
                context.SaveChanges();
                return Ok(farmRight);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/farmright/0000-0000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteFarmRight(Guid id)
        {
            try
            {
                FarmRight farmRight = context.FarmRights.Find(id);
                if (farmRight == null)
                    return NotFound();

                context.FarmRights.Remove(farmRight);
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
