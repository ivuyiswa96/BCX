using BCX.Models;
using BCX.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Interfaces
{
    public interface IEmployeeHandler
    {
        Task<Employee> CreateEmployeeAsync(EmploymentViewModel employee);
        Task<Employee> GetEmployeeAsync(int PersonId);
     List<Employee> GetEmployees();
        Task<Employee> UpdateEmployeeAsync(EmploymentViewModel employee);

    }
}
