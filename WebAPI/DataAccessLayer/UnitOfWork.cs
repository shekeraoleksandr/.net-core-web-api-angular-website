using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private Context DataBase { get; }
    //    private DepartmentRepository departmentsRepository;
    //    private EmployeeRepository employeesRepository;

    //    public UnitOfWork()
    //    {
    //        DataBase = new Context();
    //    }
    //    public IRepository<Department> Departments
    //    {
    //        get
    //        {
    //            if (departmentsRepository == null)
    //                departmentsRepository = new DepartmentRepository(DataBase);
    //            return departmentsRepository;
    //        }
    //    }
    //    public IRepository<Employee> Employees
    //    {
    //        get
    //        {
    //            if (employeesRepository == null)
    //                employeesRepository = new EmployeeRepository(DataBase);
    //            return employeesRepository;
    //        }
    //    }
    //    public void Save()
    //    {
    //        DataBase.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        DataBase.Dispose();
    //    }

    //}
}
