using MyApp.Entity.models;

namespace MyApp.db.Interfaces
{
    public interface IBalEmployee
    {
        Int32 SaveEmployee(EntityEmployee entityEmployee, ref string errMsg);
        Int32 UpdateEmployee(EntityEmployee entityEmployee, ref string errMsg);
        Int32 DeleteEmployee(Int32 employeeId, ref string errMsg);
        EntityEmployee GetDtlsEmployee(Int32 employeeId, ref string errMsg);
        List<EntityEmployee> GetAllEmployee(ref string errMsg);




    }
}
