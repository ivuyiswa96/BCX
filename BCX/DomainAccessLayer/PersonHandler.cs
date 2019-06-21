using BCX.Interfaces;
using BCX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.DomainAccessLayer
{
    public class PersonHandler : IPersonHandler
    {
        private IRepository repository;
        public PersonHandler(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<dynamic> CreatePersonAsnycAsync(Person person)
        {

            try
            {
                var results = (await repository.SearchAsync<Person>(c => c.IdNumber == person.IdNumber)).FirstOrDefault();
                if (results == null)
                {
                    var entity = await repository.AddEntityAsync(person);
                    return entity;
                }
                else
                {
                    throw new Exception  ("Person ID number Already Exist");

                }
            }
            catch (Exception ex)
            {

                throw new Exception( ex.Message);
            }
                
          
            
          
        }

        public Person GetPerson(int personId)
        {
            try
            {
              var result =  repository.Search<Person>(c=>c.PersonId==personId).Include(c=>c.ApplicationUser).FirstOrDefault();
        


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

        public async Task<Person> UpdatePersonAsnyc(Person person)
        {
            try
            {
                var results = await repository.UpdateEntityAsync(person);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
