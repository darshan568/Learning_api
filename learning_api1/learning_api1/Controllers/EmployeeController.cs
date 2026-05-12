using Microsoft.AspNetCore.Mvc;


namespace Learning_api1.Controllers
{
    //saying ASP.NET that it is apicontroller
    [ApiController]

    //routing comes from ui->api
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    //inheriting controllerbase class powers    //sometimes we use controller instead of controllerbase (controller also inherites from controllerbase and has additional features)
    {
        //creating List(vector) name is _emp
        public static List<string> _emp = new List<string>();


        [HttpGet]
        //IActionResult is used to return different types of responses from the controller action.(like: Ok, NotFound, BadRequest, etc.)
        //if we dont use, user can see the list even without logging/sign up, etc.
        public IActionResult GetEmployees()
        {
            return Ok(_emp);
        }

        [HttpPost]
        //public IActionResult AddEmployee(int Id,string name, Double salary)
        //{
        //    if (string.IsNullOrWhiteSpace(name) || Id <= 0 || salary <= 0)
        //    {
        //        return BadRequest("Invalid input. Please provide a valid name, Id, and salary.");
        //    }
        //    _emp.Add(name);
        //    _emp.Add(Id.ToString());
        //    _emp.Add(salary.ToString());
        //    return Created("", _emp);
        //}

        public IActionResult AddEmployee(Employee emp)
        {
            if (string.IsNullOrWhiteSpace(emp.Name) || emp.Id <= 0 || emp.Salary <= 0)
            {
                return BadRequest("Invalid input. Please provide a valid name, Id, and salary.");
            }
            _emp.Add(emp.Name);
            _emp.Add(emp.Id.ToString());
            _emp.Add(emp.Salary.ToString());
            return Created("", _emp);
        }
    }
}
