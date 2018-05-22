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
    public class CoinController : Controller
    {
        private XBitContext context;

        public CoinController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/coin
        public IActionResult GetCoins(string name)
        {
            try
            {
                List<Coin> coins = context.Coins.ToList();

                if (!String.IsNullOrEmpty(name))
                {
                    List<Coin> coinsToRemove = new List<Coin>(coins.Where(co => co.Name != name));
                    foreach (var coin in coinsToRemove)
                    {
                        coins.Remove(coin);
                    }
                }

                return Ok(coins);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/coin/0000-00000-000000
        [HttpGet("{id}")]
        public IActionResult GetCoin(Guid id)
        {
            try
            {
                Coin coin = context.Coins.Find(id);
                if (coin == null)
                    return NotFound();

                return Ok(coin);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/coin
        [HttpPost]
        public IActionResult PostCoin([FromBody]Coin coin)
        {
            try
            {
                context.Coins.Add(coin);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, coin);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/coin
        [HttpPut]
        public IActionResult PutCoin([FromBody]Coin coin)
        {
            try
            {
                if (!context.Coins.Any(co => co.Id == coin.Id))
                    return NotFound();

                context.Coins.Update(coin);
                context.SaveChanges();
                return Ok(coin);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/coin/0000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteCoin(Guid id)
        {
            try
            {
                Coin coin = context.Coins.Find(id);
                if (coin == null)
                    return NotFound();

                context.Coins.Remove(coin);
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
