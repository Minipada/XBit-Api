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
    public class CustomerController : Controller
    { 
        private XBitContext context;

        public CustomerController(XBitContext context)
        {
            this.context = context;
        }

        // GET api/customer
        public IActionResult GetCustomers(Guid userInformationId, Guid addressId, string farmMail)
        {
            try
            {
                List<Customer> customers = context.Customers.ToList();

                if (userInformationId != Guid.Empty)
                {
                    List<Customer> customersToRemove = new List<Customer>(customers.Where(cu => cu.UserInformationId != userInformationId));
                    foreach (var customer in customersToRemove)
                    {
                        customers.Remove(customer);
                    }
                }

                if (addressId != Guid.Empty)
                {
                    List<Customer> customersToRemove = new List<Customer>(customers.Where(cu => cu.AddressId != addressId));
                    foreach (var customer in customersToRemove)
                    {
                        customers.Remove(customer);
                    }
                }

                if (!String.IsNullOrEmpty(farmMail))
                {
                    List<Customer> customersToRemove = new List<Customer>(customers.Where(cu => cu.FarmMail != farmMail));
                    foreach (var customer in customersToRemove)
                    {
                        customers.Remove(customer);
                    }
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/customer/0000-0000-00000000
        [HttpGet("{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            try
            {
                Customer customer = context.Customers.Find(id);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/customer
        [HttpPost]
        public IActionResult PostCustomer([FromBody]Customer customer)
        {
            try
            {
                if (context.UserInformations.Find(customer.UserInformationId) == null || context.Addresses.Find(customer.AddressId) == null)
                    return BadRequest();

                context.Customers.Add(customer);
                context.SaveChanges();
                string url = Url.ActionContext.HttpContext.Request.Path;
                return Created(url, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/customer
        [HttpPut]
        public IActionResult PutCustomer([FromBody]Customer customer)
        {
            try
            {
                if (context.UserInformations.Find(customer.UserInformationId) == null || context.Addresses.Find(customer.AddressId) == null)
                    return BadRequest();

                if (context.Customers.Find(customer.Id) == null)
                    return NotFound();

                context.Customers.Update(customer);
                context.SaveChanges();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/customer/0000-00000-000000
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                Customer customer = context.Customers.Find(id);
                if (customer == null)
                    return NotFound();

                context.Customers.Remove(customer);
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
