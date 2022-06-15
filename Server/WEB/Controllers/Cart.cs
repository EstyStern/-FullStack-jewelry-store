using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL.Models;
using Entities_DTO;



namespace FinalProject_FullStack.Controllers
{
    [Route("api/[controller]")]

    public class Cart : ControllerBase
    {
        ICartBLL _CartBLL;
        public Cart(ICartBLL CartBLL)
        {
            _CartBLL = CartBLL;
        }

        [HttpPost("AddToCart/{id}")]
        public IActionResult AddCuotomer(short id,[FromBody] List<CartDTO> c)
        {
            _CartBLL.AddCart(id, c);
            return Ok(_CartBLL.AddCart(id,c));
        }


    }
}
