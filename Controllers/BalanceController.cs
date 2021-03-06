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
    public class BalanceController : Controller
    {
        private XBitContext context;

        public BalanceController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/balance
        [HttpGet]
        public IActionResult GetBalances(Guid miningFarmId, Guid coinId)
        {
            try
            {
                List<Balance> balances = context.Balances.ToList();

                if (miningFarmId != Guid.Empty)
                {
                    List<Balance> balancesToRemove = new List<Balance>(balances.Where(ba => ba.MiningFarmId != miningFarmId));
                    foreach (var balance in balancesToRemove)
                    {
                        balances.Remove(balance);
                    }
                }

                if (coinId != Guid.Empty)
                {
                    List<Balance> balancesToRemove = new List<Balance>(balances.Where(ba => ba.CoinId != coinId));
                    foreach (var balance in balancesToRemove)
                    {
                        balances.Remove(balance);
                    }
                }

                return Ok(balances);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/balance/0000-0000-0000000
        [HttpGet("{id}")]
        public IActionResult GetBalance(Guid id)
        {
            try
            {
                Balance balance = context.Balances.Find(id);
                if (balance == null)
                    return NotFound();
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/balance
        [HttpPost]
        public IActionResult PostBalance([FromBody]Balance balance)
        {
            try
            {
                if (context.Coins.Find(balance.CoinId) == null || context.MiningFarms.Find(balance.MiningFarmId) == null)
                    return BadRequest();

                context.Balances.Add(balance);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, balance);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/balance
        [HttpPut]
        public IActionResult PutBalance([FromBody]Balance balance)
        {
            try
            {
                if (context.Coins.Find(balance.CoinId) == null || context.MiningFarms.Find(balance.MiningFarmId) == null)
                    return BadRequest();

                if (!context.Balances.Any(ba => ba.Id == balance.Id))
                    return NotFound();

                context.Balances.Update(balance);
                context.SaveChanges();
                return Ok(context);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/balance/0000-0000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteBalance(Guid id)
        {
            try
            {
                Balance balance = context.Balances.Find(id);
                if (balance == null)
                    return NotFound();

                context.Balances.Remove(balance);
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
