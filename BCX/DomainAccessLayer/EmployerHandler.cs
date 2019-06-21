using BCX.Interfaces;
using BCX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.DomainAccessLayer
{
    public class EmployerHandler : IEmployerHandler
    {
        private readonly IRepository _repository;
        public EmployerHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Employer> CreateEmployeAsync(Employer employer)
        {
            try
            {
                //check if the person is already emplyment
                var results = (await _repository.SearchAsync<Employer>(c => c.PersonId == employer.PersonId)).FirstOrDefault();
                if (results == null)
                {
                    var entity = await _repository.AddEntityAsync(employer);
                    return entity;
                }
                else
                {
                    throw new Exception("This person is already employed");

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Employer> GetEmployeAsync(int PersonId)
        {
            try
            {
                var result = (await _repository.SearchAsync<Employer>(c => c.PersonId == PersonId)).FirstOrDefault();
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

        public async Task<Employer> UpdateEmployerAsync(Employer employer)
        {
            try
            {
                var results = await _repository.UpdateEntityAsync(employer);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
