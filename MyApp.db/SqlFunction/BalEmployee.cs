using MyApp.db.Interfaces;
using MyApp.db.MydbContext;
using MyApp.Entity.models;
using System.Data;

namespace MyApp.db.SqlFunctions
{
    public class BalEmployee : IBalEmployee
    {
        private readonly AppdbContext _context;


        public BalEmployee(AppdbContext context)
        {
            _context = context;
        }



        public Int32 SaveEmployee(EntityEmployee entityEmployee, ref string errMsg)
        {
            try
            {
                _context.Employees.Add(entityEmployee);
                _context.SaveChanges();
                return entityEmployee.MAST_EMPLOYEE_KEY;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return 0;
            }


        }


        public Int32 UpdateEmployee(EntityEmployee entityEmployee, ref string errMsg)
        {
            try
            {
                _context.Employees.Update(entityEmployee);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return 0;
            }


        }


        public List<EntityEmployee> GetAllEmployee(ref string errMsg)
        {

            try
            {
                return _context.Employees.Where(x => x.TAG_DELETE == 0).ToList();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }

        }
        public EntityEmployee GetDtlsEmployee(Int32 employeeId, ref string errMsg)
        {
            try
            {
                return _context.Employees.Find(employeeId);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }

        }

        public Int32 DeleteEmployee(Int32 employeeId, ref string errMsg)
        {

            try
            {
                EntityEmployee employee = _context.Employees.Find(employeeId);
                employee.TAG_DELETE = 1;
                _context.Employees.Update(employee);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 0;
            }

        }

    }
}
