using BCX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Interfaces
{
   public interface ILevelHandler
    {
        IEnumerable<LevelType> LevelTypes { get; }
       Task<LevelType> CreateLevelAsync(LevelType role);
       Task<LevelType> UpdateLevelAsync(LevelType role);
       Task<dynamic> RemoveLevelAsync(int role);
        Task<LevelType> GetLevel(int levelId);

    }
}
