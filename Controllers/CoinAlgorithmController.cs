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
    public class CoinAlgorithmController : Controller
    {
        private XBitContext context;

        public CoinAlgorithmController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/coinalgorithm
        [HttpGet]
        public IActionResult GetCoinALgorithms(Guid algorithmId, Guid coinId)
        {
            try
            {
                List<CoinAlgorithm> coinAlgorithms = context.CoinAlgorithms.ToList();

                if (algorithmId != Guid.Empty)
                {
                    List<CoinAlgorithm> caToRemove = new List<CoinAlgorithm>(coinAlgorithms.Where(ca => ca.AlgorithmId != algorithmId));
                    foreach (var ca in caToRemove)
                    {
                        coinAlgorithms.Remove(ca);
                    }
                }

                if (coinId != Guid.Empty)
                {
                    List<CoinAlgorithm> caToRemove = new List<CoinAlgorithm>(coinAlgorithms.Where(ca => ca.CoinId != coinId));
                    foreach (var ca in caToRemove)
                    {
                        coinAlgorithms.Remove(ca);
                    }
                }

                return Ok(coinAlgorithms);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/coinalgorithm/000000000-0000-0000
        [HttpGet("{id}")]
        public IActionResult GetConAlgorithm(Guid id)
        {
            try
            {
                CoinAlgorithm coinAlgorithm = context.CoinAlgorithms.Find(id);
                if (coinAlgorithm == null)
                    return NotFound();
                return Ok(coinAlgorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/coinalgorithm
        [HttpPost]
        public IActionResult PostCoinALgorithm([FromBody]CoinAlgorithm coinAlgorithm)
        {
            try
            {
                if (context.Algorithms.Find(coinAlgorithm.AlgorithmId) == null || context.Coins.Find(coinAlgorithm.CoinId) == null)
                    return BadRequest();

                context.CoinAlgorithms.Add(coinAlgorithm);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, coinAlgorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/coinalgorithm
        [HttpPut]
        public IActionResult PutCoinAlgorithm([FromBody]CoinAlgorithm coinAlgorithm)
        {
            try
            {
                if (context.Algorithms.Find(coinAlgorithm.AlgorithmId) == null || context.Coins.Find(coinAlgorithm.CoinId) == null)
                    return BadRequest();

                if (context.CoinAlgorithms.Any(ca => ca.Id == coinAlgorithm.Id))
                    return NotFound();

                context.CoinAlgorithms.Update(coinAlgorithm);
                context.SaveChanges();
                return Ok(coinAlgorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/coinalgorithm/0000-0000-0000000
        [HttpDelete("{id}")]
        public  IActionResult DeleteCoinAlgorithm(Guid id)
        {
            try
            {
                CoinAlgorithm coinAlgorithm = context.CoinAlgorithms.Find(id);
                if (coinAlgorithm == null)
                    return NotFound();
                context.CoinAlgorithms.Remove(coinAlgorithm);
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
