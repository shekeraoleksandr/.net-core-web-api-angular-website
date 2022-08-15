using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class DepartmentRepository
    {
        private Context DB;
        public DepartmentRepository(Context context)
        {
            DB = context;
        }

        public Department Read(int id)
        {
            return DB.Departments.Find(id);
        }
        public void Create(Department department)
        {
            DB.Departments.Add(department);
            DB.SaveChanges();
        }
        public void Update(Department department)
        {
                DB.Departments.Update(department);
                DB.SaveChanges();
        }
        public void Delete(int id)
        {
            Department department = DB.Departments.Find(id);
            if (department != null)
            {
                DB.Departments.Remove(department);
                DB.SaveChanges();
            }
        }
    }
}
