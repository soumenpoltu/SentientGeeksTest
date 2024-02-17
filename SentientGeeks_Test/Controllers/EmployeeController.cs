using BusinessLogic.Helper.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SentientGeeks_Test.Controllers
{
    [ApiController]
    [Route("api/employee/")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeLogic _employeeLogic;
        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        [HttpPost]
        [Route("SaveEmployee")]
        public IActionResult SaveEmployee(IFormCollection entityEmployee)
        {
            string token = "";
            if (entityEmployee != null)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = _employeeLogic.SaveEmployee(entityEmployee, Convert.ToInt32(userId));
                return Ok(new { result = result });

            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(IFormCollection entityEmployee)
        {
            string token = "";
            if (entityEmployee != null)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = _employeeLogic.UpdateEmployee(entityEmployee, Convert.ToInt32(userId));
                return Ok(new { result = result });

            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            var result = _employeeLogic.GetAllEmployee();
            return Ok(new { result = result });

        }

        [HttpGet]
        [Route("GetDtlsEmployee")]
        public IActionResult GetDtlsEmployee(Int32 empId = 0)
        {
            if (empId > 0)
            { 
                var result = _employeeLogic.GetDtlsEmployee(empId);
                return Ok(new { result = result });
            }
            else
                return BadRequest();

        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(string empId = null)
        {
            if (empId != null)
            {

                var result = _employeeLogic.DeleteEmployee(empId);
                return Ok(new { result = result });
            }
            else
                return BadRequest();

        }

    }
}