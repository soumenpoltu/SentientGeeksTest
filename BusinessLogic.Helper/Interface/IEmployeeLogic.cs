using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Helper.Interface
{
    public  interface IEmployeeLogic
    {
        string SaveEmployee(IFormCollection fm, int entuserkey);
        string UpdateEmployee(IFormCollection fm, int entuserkey);
        string GetAllEmployee();
        string GetDtlsEmployee(Int32 employeeId);
        string DeleteEmployee(string employeeId);

    }
}
