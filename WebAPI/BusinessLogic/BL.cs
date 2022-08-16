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
            DB.Departments.Create(Mapper.Map<Department>(department));
            DB.Save();
        }
        public void AddEmployee(EmployeeBL employee)
        {
            DB.Employees.Create(Mapper.Map<Employee>(employee));
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
            if(toUpdate != null)
            {
                toUpdate = Mapper.Map<Department>(department);
                DB.Departments.Update(toUpdate);
                DB.Save();
            }
        }
        public void UpdateEmployee(EmployeeBL employee)
        {
            Employee toUpdate = DB.Employees.Read(employee.EmployeeId);
            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Employee>(employee);
                DB.Employees.Update(toUpdate);
                DB.Save();
            }
        }
        public IEnumerable<DepartmentBL> GetDepartments()
        {
            List<DepartmentBL> result = new List<DepartmentBL>();
            foreach(var item in DB.Departments.ReadAll())
            {
                result.Add(Mapper.Map<DepartmentBL>(item));
            }
            return result;
        }
        public IEnumerable<EmployeeBL> GetEmployees()
        {
            List<EmployeeBL> result = new List<EmployeeBL>();
            foreach (var item in DB.Employees.ReadAll())
            {
                result.Add(Mapper.Map<EmployeeBL>(item));
            }
            return result;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
