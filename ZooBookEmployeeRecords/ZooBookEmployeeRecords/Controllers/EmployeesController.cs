using ESL.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBookEmployeeRecords.Data;
using ZooBookEmployeeRecords.Models;

namespace ZooBookEmployeeRecords.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_unitOfWork.Employee.GetAll());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployees(int id)
        {
            return Ok(_unitOfWork.Employee.GetFirstOrDefault(x=>x.Id==id));
        }
        
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult SaveEmployee(Employee employee)
        {
            if(employee.FirstName=="" && employee.MiddleName=="" && employee.LastName=="")
            {
                return Ok(new { success = false,message="Unable to save" });
            }
            _unitOfWork.Employee.Add(employee);
            _unitOfWork.Save();
            return Ok(new { success=true, message = "Save successfully" });
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployee(Employee employee,int id)
        {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(x=>x.Id==id);
            if(obj==null)
            {
                return NotFound($"{id} is not found");
            }
            obj.FirstName = employee.FirstName;
            obj.MiddleName = employee.MiddleName;
            obj.LastName = employee.LastName;
            _unitOfWork.Employee.Update(obj);
            _unitOfWork.Save();
            return Ok(new { success=true, message = "Update successfully" });
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(x=>x.Id==id);
            if(obj==null)
            {
                return NotFound($"{id} is not found for delete");
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            return Ok(new { success=true, message = "Deleted successfully" });
        }

    }
}
