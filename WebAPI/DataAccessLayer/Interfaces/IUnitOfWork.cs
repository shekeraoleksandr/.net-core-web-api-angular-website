using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> Departmens { get; }
        IRepository<Employee> Employees { get; }
        void Save();
    }
}
