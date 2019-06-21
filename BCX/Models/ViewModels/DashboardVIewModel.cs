using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models.ViewModels
{
    public class DashboardVIewModel
    {
        public List<Person> Persons = new List<Person>();
        public List<Employee> Employees = new List<Employee>();
        public List<TaskType> Tasks = new List<TaskType>();
        public List<LevelType> Levels = new List<LevelType>();
        
    }

}
