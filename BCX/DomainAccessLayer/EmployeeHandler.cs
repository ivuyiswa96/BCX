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
    public class EmployeeHandler : IEmployeeHandler
    {
        private readonly IRepository _repository;
        public EmployeeHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> CreateEmployeeAsync(EmploymentViewModel employee)
        {
            try
            {
                //check if the person is already emplyment
                var results = (await _repository.SearchAsync<Employee>(c => c.PersonId == employee.PersonId)).FirstOrDefault();
                if (results == null)
                {

                    var _employee = Mapper.Map(new Employee(), employee);
                    _employee.LevelTypeId = employee.LevelType.LevelTypeId;
                    _employee.LevelType = null;
                    var entity = await _repository.AddEntityAsync(_employee);
                    return entity;
                }
                else
                {
                    throw new Exception( "This person is already employed");

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> GetEmployeeAsync(int PersonId)
        {
            try
            {
                var result = (await _repository.SearchAsync<Employee>(c => c.PersonId == PersonId)).FirstOrDefault();
                if (result != null)
                    return result;
                else
                    throw new Exception("The system dont have this record");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<Employee> GetEmployees()
        {
            return   _repository.Search<Employee>(c => c.EmployeeId>0 ).Include(p=>p.Person).ThenInclude(k=>k.ApplicationUser).Include(c=>c.LevelType).ToList();
        }

        public async Task<Employee> UpdateEmployeeAsync(EmploymentViewModel employee)
        {
            try
            {
                var _employee = Mapper.Map(new Employee(), employee);
                var results = await _repository.UpdateEntityAsync(_employee);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
