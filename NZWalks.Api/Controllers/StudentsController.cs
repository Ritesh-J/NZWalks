using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Api.Controllers
{
    // https://localhost:portnumber/api/students(NameOfController)
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents() {
            //Create a String array and store name of students
            string[] studentName = new string[] { "John", "Jane", "Mark", "Emily", "David" };
            //return studentName with HTTP Response Ok status
            return Ok(studentName);
        }
    }
}
