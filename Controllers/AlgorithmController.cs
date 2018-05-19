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

        // GET api/algorithm/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetAlgorithm(Guid id)
        {
            Algorithm algo = context.Algorithms.Find(id);
            if (algo == null)
                return NotFound();
            return Ok(algo);
        }

        // POST api/algorithm
        [HttpPost]
        public IActionResult PostAlgorithm([FromBody]Algorithm algorithm)
        {
            context.Algorithms.Add(algorithm);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, algorithm);
        }

        // PUT api/algorithm
        [HttpPut]
        public IActionResult PutAlgorithm([FromBody]Algorithm algorithm)
        {
            if (context.Algorithms.Any(alg => alg.Id == algorithm.Id))
            {
                context.Update(algorithm);
                context.SaveChanges();
                return Ok(algorithm);
            }
            return NotFound();
        }

        // DELETE api/algorithm/00000-00000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteAlgorithm(Guid id)
        {
            Algorithm algorithm = context.Algorithms.Find(id);
            if (algorithm == null)
                return NotFound();
            context.Algorithms.Remove(algorithm);
            context.SaveChanges();
            return Ok();
        }
    }
}
