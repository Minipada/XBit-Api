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
    public class AdministratorController : Controller
    {
        private XBitContext context;

        public AdministratorController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/administrator
        [HttpGet]
        public IActionResult GetAdministrators(Guid userInformationId)
        {
            List<Administrator> administrators = context.Administrators.ToList();

            if (userInformationId != Guid.Empty)
            {
                List<Administrator> adminsToRemove = new List<Administrator>(administrators.Where(adm => adm.UserInformationId != userInformationId));
                foreach (Administrator admin in adminsToRemove)
                {
                    administrators.Remove(admin);
                }
            }

            return Ok(administrators);
        }

        // GET api/administrator/0000-000-000000
        [HttpGet("{id}")]
        public IActionResult GetAdministrator(Guid id)
        {
            Administrator admin = context.Administrators.Find(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // POST api/administrator
        [HttpPost]
        public IActionResult PostAdministrator([FromBody]Administrator administrator)
        {
            if (context.UserInformations.Find(administrator.UserInformation) != null)
            {
                context.Administrators.Add(administrator);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, administrator);
            }

            return BadRequest();
        }

        // PUT api/administrator
        [HttpPut]
        public IActionResult PutAdministrator([FromBody]Administrator administrator)
        {
            if (context.UserInformations.Find(administrator.UserInformationId) == null)
                return BadRequest();

            if (context.Administrators.Any(admin => admin.Id == administrator.Id))
            {
                context.Administrators.Update(administrator);
                context.SaveChanges();
                return Ok(administrator);
            }

            return NotFound();
        }

        // DELETE api/administrator/000-000-0000000
        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrator(Guid id)
        {
            Administrator adminToRemove = context.Administrators.Find(id);
            if (adminToRemove == null)
                return NotFound();

            context.Administrators.Remove(adminToRemove);
            context.SaveChanges();
            return Ok();
        }
    }
}
