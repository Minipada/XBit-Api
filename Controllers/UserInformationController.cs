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
    public class UserInformationController : Controller
    {
        private XBitContext context;

        public UserInformationController(XBitContext context)
        {
            this.context = context;
        }

        // GET pai/userinformation
        [HttpGet]
        public IActionResult GetUserInformations(string name, string surname, string email, string phone, DateTime birthDate, string username)
        {
            List<UserInformation> userInformations = context.UserInformations.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.Name != name));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            if (!String.IsNullOrEmpty(surname))
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.Surname != surname));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            if (!String.IsNullOrEmpty(email))
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.Email != email));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            if (!String.IsNullOrEmpty(phone))
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.Phone != phone));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            if (!String.IsNullOrEmpty(username))
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.Username != username));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            if (birthDate != null)
            {
                List<UserInformation> uiToRemove = new List<UserInformation>(userInformations.Where(ui => ui.BirthDate != birthDate));
                foreach (var ui in uiToRemove)
                {
                    userInformations.Remove(ui);
                }
            }

            return Ok(userInformations);
        }

        // GET api/userinformation/0000-00000-0000000
        [HttpGet("{id}")]
        public IActionResult GetUserInformation(Guid id)
        {
            UserInformation userInformation = context.UserInformations.Find(id);
            if (userInformation == null)
                return NotFound();
            return Ok(userInformation);
        }

        // POST api/userinformation
        [HttpPost]
        public IActionResult PostUserInformation([FromBody]UserInformation userInformation)
        {
            context.UserInformations.Add(userInformation);
            context.SaveChanges();
            string url = Url.ActionContext.HttpContext.Request.Path;
            return Created(url, userInformation);
        }

        // PUT api/userinformation
        [HttpPut]
        public IActionResult PutUserInformation([FromBody]UserInformation userInformation)
        {
            if (!context.UserInformations.Any(ui => ui.Id == userInformation.Id))
                return NotFound();

            context.UserInformations.Update(userInformation);
            context.SaveChanges();
            return Ok(userInformation);
        }

        // DELETE api/userinformation/0000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteUserInformation(Guid id)
        {
            UserInformation userInformation = context.UserInformations.Find(id);
            if (userInformation == null)
                return NotFound();
            context.UserInformations.Remove(userInformation);
            context.SaveChanges();
            return Ok();
        }
    }
}
