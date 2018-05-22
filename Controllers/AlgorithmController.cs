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
    public class AlgorithmController : Controller
    {
        private XBitContext context;

        public AlgorithmController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/algorithm
        [HttpGet]
        public IActionResult GetAlgorithms(string name)
        {
            try
            {
                List<Algorithm> algorithms = context.Algorithms.ToList();

                if (!String.IsNullOrEmpty(name))
                {
                    List<Algorithm> algosToRemove = new List<Algorithm>(algorithms.Where(algo => algo.Name != name));
                    foreach (Algorithm algo in algosToRemove)
                    {
                        algorithms.Remove(algo);
                    }
                }

                return Ok(algorithms);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/algorithm/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetAlgorithm(Guid id)
        {
            try
            {
                Algorithm algo = context.Algorithms.Find(id);
                if (algo == null)
                    return NotFound();
                return Ok(algo);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/algorithm
        [HttpPost]
        public IActionResult PostAlgorithm([FromBody]Algorithm algorithm)
        {
            try
            {
                context.Algorithms.Add(algorithm);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, algorithm);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/algorithm
        [HttpPut]
        public IActionResult PutAlgorithm([FromBody]Algorithm algorithm)
        {
            try
            {
                if (context.Algorithms.Any(alg => alg.Id == algorithm.Id))
                {
                    context.Update(algorithm);
                    context.SaveChanges();
                    return Ok(algorithm);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/algorithm/00000-00000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteAlgorithm(Guid id)
        {
            try
            {
                Algorithm algorithm = context.Algorithms.Find(id);
                if (algorithm == null)
                    return NotFound();
                context.Algorithms.Remove(algorithm);
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
