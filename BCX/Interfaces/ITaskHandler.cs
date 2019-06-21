using BCX.Models;
using BCX.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Interfaces
{
    public interface ITaskHandler
    {
        Task<EmploymentViewModel> CreateTaskAsnyc(EmploymentViewModel employmentViewModel);
        Task<EmploymentViewModel> UpdateTaskAsnyc(EmploymentViewModel employmentViewModel);
        Task<dynamic> RemoveTaskAsnyc(int taskId);
        double CalculateSalary(EmploymentViewModel employmentViewModel);
        Task<EmploymentViewModel> AddTimeAsnyc(int time,int employmentId);
        bool CheckIntervals(int employeeId,int HourWorked);
        List<TaskType> GetTaskByEmpId(int EmpId);
        TaskType GetTaskById(int EmpId);
            
        IEnumerable<TaskType> TaskTypes { get; }

    }
}
