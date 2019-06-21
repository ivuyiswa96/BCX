using BCX.Helpers;
using BCX.Interfaces;
using BCX.Models;
using BCX.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.DomainAccessLayer
{
    public class TaskHandler : ITaskHandler
    {
        private readonly IRepository _repository;
        public TaskHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskType> TaskTypes => _repository.All<TaskType>();

        public async Task<EmploymentViewModel> AddTimeAsnyc(int hour,int employeeId)
        {
            var employee = (await _repository.SearchAsync<Employee>(c => c.EmployeeId == employeeId)).FirstOrDefault();
            employee.HourWorked = hour;
            return Mapper.Map(new EmploymentViewModel(),employee);
        }


        public double CalculateSalary(EmploymentViewModel employmentViewModel)
        {
            var total = 0.0;
            var tasks = _repository.Search<TaskType>(c => c.EmployeeId == employmentViewModel.EmployeeId).ToList();
            foreach (var item in tasks)
            {
                total += item.RatePerHour;
            }
            return total;
        }

        public bool CheckIntervals(int employeeId,int hour)
        {
            var employee = _repository.Search<TaskType>(c => c.EmployeeId == employeeId).ToList();
            var hours = employee.Sum(c => c.Duration.Hours) + hour;
          //  var hours = _repository.Search<TaskType>(c => c.EmployeeId > employeeId).Sum(t => t.Duration.Hours) +hour;
            if (hours<=12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<EmploymentViewModel> CreateTaskAsnyc(EmploymentViewModel employmentViewModel)
        {
            try
            {

                if (CheckIntervals(employmentViewModel.EmployeeId,employmentViewModel.HourWorked)==true)
                {
                    employmentViewModel.Duration = TimeSpan.FromHours(employmentViewModel.HourWorked);
                        
                    var _task = Mapper.Map(new TaskType(), employmentViewModel);
                    var levelId = _repository.Search<Employee>(c => c.EmployeeId == employmentViewModel.EmployeeId).FirstOrDefault().LevelTypeId;
                    var price =_repository.Search<LevelType>(c=>c.LevelTypeId==levelId).
                        FirstOrDefault().Price;
                    _task.RatePerHour = price;
                    var results = await _repository.AddEntityAsync(_task);

                    return Mapper.Map(new EmploymentViewModel(), results);
                    
                }
                else
                {
                    throw new Exception("Your tasks are exceeding 12 Hours");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        
        }

        public  List<TaskType> GetTaskByEmpId(int EmpId)
        {
            var tasks = _repository.Search<TaskType>(c => c.EmployeeId == EmpId).Include(s => s.Employee).ThenInclude(k => k.LevelType).ToList();
            return tasks;
        }

        public TaskType GetTaskById(int EmpId)
        {
            var tasks = _repository.Search<TaskType>(c => c.TaskTypeId == EmpId).Include(s => s.Employee).ThenInclude(k => k.LevelType).FirstOrDefault();
            return tasks;
        }

        public async Task<dynamic> RemoveTaskAsnyc(int taskId)
        {
            try
            {
                var task = await _repository.Search<TaskType>(c => c.TaskTypeId == taskId).FirstOrDefaultAsync();
                _repository.DeleteEntity(task);
                _repository.Save();
                    return ("Task successfully deleted");
           }
            catch (Exception e)
           {
        
                    throw new Exception(e.Message);
                }


            }

        public async Task<EmploymentViewModel> UpdateTaskAsnyc(EmploymentViewModel employmentViewModel)
        {
            try
            {
                var _task = Mapper.Map(new TaskType(), employmentViewModel);
                var results = await _repository.UpdateEntityAsync(_task);
                return Mapper.Map(new EmploymentViewModel(),results);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

       
        }
    }
}
