using System.Collections.Generic;
using class01.Model;

namespace class01.Services
{
    public interface IPersonService
    {
         Person Create(Person person);
         Person FindById(long id);
         List<Person> FindAll();
         Person Update(Person person);
         void Delete(long id);
    }
}