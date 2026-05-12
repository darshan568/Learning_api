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
        //public static List<string> _emp = new List<string>();
        public static List<Employee> _emp = new List<Employee>();


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

        public IActionResult AddEmployee(int id, string name, double salary)
        {
            if (string.IsNullOrWhiteSpace(name) || id <= 0 || salary <= 0)
            {
                return BadRequest("Invalid input. Please provide a valid name, Id, and salary.");
            }
            Employee newEmplbox = new Employee
            {
                Id = id,
                Name = name,
                Salary = salary
            };
            _emp.Add(newEmplbox);
            return Created("", _emp);
        }

       

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            //if(id<=0)
            //{
            //    return BadRequest("Invalid input. Please provide a valid Id.");
            //}
            //return Ok(_emp);
            var ee = _emp.FirstOrDefault(e => e.Id == id);   //lamda  , this Id is from class 
            //FirstOrDefault - 1)First: compiler will start from 1st index compares the id if true returns it and exit . else gives 400
                                //2)OrDefault: inorder to avoid 400 we use this along with First ->if true returns it and exit . else gives null
            if (ee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(ee);

        }
    }
}
