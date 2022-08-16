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


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {

            List<Department> departments = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
            using (var db = new BL())
            {
                departments = mapper.Map<List<Department>>(db.GetDepartments());
                return new JsonResult(departments);
            }
        }
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            var department = new DepartmentBL()
            {
                DepartmentName = dep.DepartmentName
            };
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
            using (var db = new BL())
            {
                db.AddDepartment(mapper.Map<DepartmentBL>(department));
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Department dep)
        {
            var department = new DepartmentBL()
            {
                DepartmentId = dep.DepartmentId,
                DepartmentName = dep.DepartmentName
            };
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
            using (var db = new BL())
            {
                db.UpdateDepartment(mapper.Map<DepartmentBL>(department));
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            using (var db = new BL())
            {
                db.RemoveDepartment(id);
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}