using System;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using BusinessLogic.Entities;
using AutoMapper;

namespace BusinessLogic
{

    public class BL : IDisposable
    {
        private UnitOfWork DB { get; }
        public BL()
        {
            DB = new UnitOfWork();
        }
        public void AddDepartment(DepartmentBL department)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
            DB.Departments.Create(mapper.Map<Department>(department));
            DB.Save();
        }
        public void AddEmployee(EmployeeBL employee)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeBL, Employee>());
            var mapper = new Mapper(config);
            DB.Employees.Create(mapper.Map<Employee>(employee));
            DB.Save();
        }
        public void RemoveDepartment(int id)
        {
            DB.Departments.Delete(id);
            DB.Save();
        }
        public void RemoveEmployee(int id)
        {
            DB.Employees.Delete(id);
            DB.Save();
        }
        public void UpdateDepartment(DepartmentBL department)
        {
            Department toUpdate = DB.Departments.Read(department.DepartmentId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentBL, Department>());
            var mapper = new Mapper(config);
            if (toUpdate != null)
            {
                toUpdate = mapper.Map<Department>(department);
                DB.Departments.Update(toUpdate);
                DB.Save();
            }
        }
        public void UpdateEmployee(EmployeeBL employee)
        {
            Employee toUpdate = DB.Employees.Read(employee.EmployeeId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeBL, Employee>());
            var mapper = new Mapper(config);
            if (toUpdate != null)
            {
                toUpdate = mapper.Map<Employee>(employee);
                DB.Employees.Update(toUpdate);
                DB.Save();
            }
        }
        public IEnumerable<DepartmentBL> GetDepartments()
        {
            List<DepartmentBL> result = new List<DepartmentBL>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentBL>());
            var mapper = new Mapper(config);
            foreach (var item in DB.Departments.ReadAll())
            {
                result.Add(mapper.Map<DepartmentBL>(item));
            }
            return result;
        }
        public IEnumerable<EmployeeBL> GetEmployees()
        {
            List<EmployeeBL> result = new List<EmployeeBL>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeBL>());
            var mapper = new Mapper(config);
            foreach (var item in DB.Employees.ReadAll())
            {
                result.Add(mapper.Map<EmployeeBL>(item));
            }
            return result;
        }
        public void Dispose()
        {
            DB.Dispose();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }
}
