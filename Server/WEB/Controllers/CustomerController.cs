using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Entities_DTO;

namespace FinalProject_FullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        //BLL משתנה פרטי מסוג שכבת
        ICustomers_BLL _customerBll;
        public CustomerController(ICustomers_BLL _cBll)
        {
            _customerBll = _cBll;
        }

        //AddCustomer
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customers_DTO c)
        {
            return Ok(_customerBll.AddCustomer(c));
        }
            
        //GetCustomerByNameAndPassword
        [HttpGet("GetCustomerByNameAndPassword/{Name}/{Password}")]
        public IActionResult GetCustomerByNameAndPassword(string Name, int Password)
        {
            return Ok(_customerBll.GetCustomerByNameAndPassword(Name, Password));
        }

    }
}
