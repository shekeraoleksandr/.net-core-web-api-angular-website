using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;
using BusinessLogic.Entities;
using WebAPI.Models;
using WebAPI.MappingConfig;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Employee> employees = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeBL, Employee>());
            var mapper = new Mapper(config);
            using (var db = new BL())
            {
                employees = mapper.Map<List<Employee>>(db.GetEmployees());
                return new JsonResult(employees);
            }
        }
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            var employee = new EmployeeBL()
            {
                EmployeeName = emp.EmployeeName,
                DepartmentName = emp.DepartmentName,
                DateOfJoining = emp.DateOfJoining,
                PhotoFileName = emp.PhotoFileName
            };
            using (var db = new BL())
            {
                db.AddEmployee(employee);
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            var employee = new EmployeeBL()
            {
                EmployeeId = emp.EmployeeId,
                DepartmentName = emp.DepartmentName,
                DateOfJoining = emp.DateOfJoining,
                EmployeeName = emp.EmployeeName,
                PhotoFileName = emp.PhotoFileName
            };
            using (var db = new BL())
            {
                db.UpdateEmployee(employee);
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            using (var db = new BL())
            {
                db.RemoveEmployee(id);
            }
            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFiles = httpRequest.Files[0];
                string filename = postedFiles.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFiles.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            List<Employee> employees = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeBL, Employee>());
            var mapper = new Mapper(config);
            using (var db = new BL())
            {
                employees = mapper.Map<List<Employee>>(db.GetEmployees());
                var departmentNames = from emp in employees
                            select new
                            {
                                emp.DepartmentName
                            };
                return new JsonResult(departmentNames);
            }
        }
    }
}
