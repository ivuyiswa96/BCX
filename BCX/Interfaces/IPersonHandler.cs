using BCX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Interfaces
{
   public interface IPersonHandler
    {
      Task<dynamic> CreatePersonAsnycAsync(Person person );
     Person GetPerson(int PersonId );
      Task<Person> UpdatePersonAsnyc(Person person );

    }
}
