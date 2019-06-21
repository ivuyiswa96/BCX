using BCX.Interfaces;
using BCX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.DomainAccessLayer
{
    public class LevelHandler : ILevelHandler
    {
        private readonly IRepository repository;
        public LevelHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<LevelType> LevelTypes => repository.All<LevelType>();

        public async Task<LevelType> CreateLevelAsync(LevelType role)
        {
            try
            {
                //check if the person is already emplyment
                var results = (await repository.SearchAsync<LevelType>(c => c.Description == role.Description)).FirstOrDefault();
                if (results == null)
                {
                    var entity = await repository.AddEntityAsync(role);
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

        public async Task<LevelType> GetLevel(int levelId)
        {
            var task = await repository.Search<LevelType>(c => c.LevelTypeId == levelId).FirstOrDefaultAsync();
            return task;
        }

        public async Task<dynamic> RemoveLevelAsync(int roleId)
        {
            try
            {
                var task = await repository.Search<LevelType>(c => c.LevelTypeId == roleId).FirstOrDefaultAsync();
                repository.DeleteEntity(task);
                repository.Save();
                return ("Task successfully deleted");
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<LevelType> UpdateLevelAsync(LevelType role)
        {
            try
            {
    
                var results = await repository.UpdateEntityAsync(role);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
