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
    public class JewelryController : ControllerBase
    {
        //BLL משתנה פרטי מסוג שכבת
        IJewelry_BLL _JewelryBll;
        public JewelryController(IJewelry_BLL _jBll)
        {
            _JewelryBll = _jBll;
        }

        

        //הסרת תכשיט מהרשימה
        [HttpDelete("RemoveJewelryById/{id}")]
        public IActionResult RemoveJewelryById(short id)
        {
            return Ok(_JewelryBll.RemoveJewelryById(id));
        }
        

        ////הוספה לרשימת התכשיטים
        [HttpPost("AddJewelry")]
        public IActionResult AddJewelry([FromBody] Jewelry_DTO j)
        {
            return Ok(_JewelryBll.AddJewelry(j));
        }

        //שליפת תכשיט לפי קוד
        [HttpGet("getJewelryById/{id}")]
        public IActionResult getJewelryById(short id)
        {
            return Ok(_JewelryBll.getJewelryById(id));
        }
        //שליפת רשימת תכשיטים
        [HttpGet("GetAllJewelry")]
        public IActionResult GetAllJewelry()
        {
            return Ok(_JewelryBll.GetAllJewelry());
        }


        //שליפת תכשיטים לפי קטגוריה מבוקשת
        [HttpGet("getJewelrysByCodeCategory/{Code}")]
        public IActionResult getJewelrysByCodeCategory(short Code)
        {
            return Ok(_JewelryBll.getJewelrysByCodeCategory(Code));
        }



        //עדכון תכשיט ברשימה לפי קוד---?????
        //מחזיר][?????
        [HttpPut("UpdateJewelry")]
        public IActionResult UpdateJewelry([FromBody] Jewelry_DTO j)
        {
            return Ok(_JewelryBll.UpdateJewelry(j));
        }


    }
}
