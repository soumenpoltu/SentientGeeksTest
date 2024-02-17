using AutoMapper;
using BusinessLogic.Helper.Interface;
using Microsoft.AspNetCore.Http;
using MyApp.db.Interfaces;
using MyApp.Entity.models;
using Newtonsoft.Json;

namespace BusinessLogic.Helper.Logics
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IBalEmployee _balEmployee;
        private readonly IMapper _mapper;
        String errMsg = String.Empty;
        public EmployeeLogic(IBalEmployee balEmployee, IMapper mapper)
        {
            _balEmployee = balEmployee;
            _mapper = mapper;

        }

        public string SaveEmployee(IFormCollection fm, int entuserkey)
        {
            try
            {
                errMsg = String.Empty;
                EntityEmployee ep = _mapper.Map<IFormCollection, EntityEmployee>(fm);
                ep.ENT_USER_KEY = entuserkey;
                ep.EDIT_USER_KEY = 0;
                ep.ENT_DATE = DateTime.Now;
                ep.EDIT_DATE = DateTime.Now;
                _balEmployee.SaveEmployee(ep, ref errMsg);
                if (String.IsNullOrEmpty(errMsg))
                    return "true";
                else
                    return "false";


            }
            catch (Exception ex)
            {
                return "false";
            }

        }

        public string UpdateEmployee(IFormCollection fm, int entuserkey)
        {
            try
            {
                errMsg = String.Empty;
                EntityEmployee ep = _mapper.Map<IFormCollection, EntityEmployee>(fm);
                ep.EDIT_USER_KEY = entuserkey;
                ep.EDIT_DATE = DateTime.Now;
                _balEmployee.UpdateEmployee(ep, ref errMsg);
                if (String.IsNullOrEmpty(errMsg))
                    return "true";
                else
                    return "false";


            }
            catch (Exception ex)
            {
                return "false";
            }

        }

        public string GetAllEmployee()
        {
            try
            {
                errMsg = String.Empty;
                List<EntityEmployee> employees = _balEmployee.GetAllEmployee(ref errMsg);
                if (String.IsNullOrEmpty(errMsg))
                    return JsonConvert.SerializeObject(employees);
                else
                    return "false";


            }
            catch (Exception ex)
            {
                return "false";
            }

        }

        public string GetDtlsEmployee(Int32 employeeId)
        {
            try
            {
                errMsg = String.Empty;
                EntityEmployee employees = _balEmployee.GetDtlsEmployee(employeeId, ref errMsg);
                if (String.IsNullOrEmpty(errMsg))
                    return JsonConvert.SerializeObject(employees);
                else
                    return "false";

            }
            catch (Exception ex)
            {
                return "false";
            }

        }

        public string DeleteEmployee(string employeeId)
        {
            try
            {
                errMsg = String.Empty;
                var keys = employeeId.Split(',');
                foreach (var key in keys)
                {
                    if (key != "")
                    {
                        _balEmployee.DeleteEmployee(Convert.ToInt32(key), ref errMsg);
                        if (String.IsNullOrEmpty(errMsg))
                            continue;
                        else
                            return "false";

                    }
                }
                if (String.IsNullOrEmpty(errMsg))
                    return "true";
                else
                    return "false";


            }
            catch (Exception ex)
            {
                return "false";
            }

        }

    }
}
