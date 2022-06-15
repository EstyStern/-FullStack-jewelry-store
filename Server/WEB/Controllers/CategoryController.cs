using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Entities_DTO;

namespace FinalProject_FullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        //BLL משתנה פרטי מסוג שכבת
        ICategory_BLL _CategoryBll;
        public CategoryController(ICategory_BLL _cBll)
        {
            _CategoryBll = _cBll;
        }

        //שליפת רשימת קטגוריות
        [HttpGet("GetAllCategorys")]
        public IActionResult GetAllCategorys()
        {
            return Ok(_CategoryBll.GetAllCategorys());
        }
        //עדכון קטגוריה ברשימה
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] Category_DTO c)
        {
            return Ok(_CategoryBll.UpdateCategory(c));
        }

        //הסרת קטגוריה מהרשימה
        [HttpDelete("RemoveCategoryByCode/{Code}")]
        public IActionResult RemoveCategoryByCode(short Code)
        {
            return Ok(_CategoryBll.RemoveCategoryByCode(Code));
        }

        //הוספה לרשימת הקטגוריות
        [HttpPost("AddCategory")]
        public IActionResult AddCategory([FromBody] Category_DTO c)
        {
            return Ok(_CategoryBll.AddCategory(c));
        }

        //שליפת קטגוריה לפי קוד
        [HttpGet("GetCategoryByCode/{Code}")]
        public IActionResult GetCategoryByCode(short Code)
        {
            return Ok(_CategoryBll.GetCategoryByCode(Code));
        }
    }
}
