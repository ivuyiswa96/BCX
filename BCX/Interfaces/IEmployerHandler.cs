using BCX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Interfaces
{
   public interface IEmployerHandler
    {
        Task<Employer> CreateEmployeAsync(Employer employer);
        Task<Employer> GetEmployeAsync(int PersonId);
        Task<Employer> UpdateEmployerAsync(Employer employer);
    }
}
