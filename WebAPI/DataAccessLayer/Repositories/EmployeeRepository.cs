using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository
    {
        private Context DB;
        public EmployeeRepository(Context context)
        {
            DB = context;
        }

        public Employee Read(int id)
        {
            return DB.Employees.Find(id);
        }
        public void Create(Employee employee)
        {
            DB.Employees.Add(employee);
        }
        public void Update(Employee employee)
        {
            DB.Employees.Update(employee);
        }
        public void Delete(int id)
        {
            Employee employee = DB.Employees.Find(id);
            if (employee != null)
                DB.Employees.Remove(employee);
        }
    }
}
