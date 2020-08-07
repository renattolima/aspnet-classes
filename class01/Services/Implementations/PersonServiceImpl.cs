using System;
using System.Collections.Generic;
using System.Threading;
using class01.Model;

namespace class01.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person p = MockPerson(i);
                persons.Add(p);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person{
                Id = IncrementAndGet(),
                FirstName = (i%2==0? "Fulano" : "Ciclano")+i,
                LastName = (i%3==0? "Silva" : "Oliveira")+i,
                Address = "My house"+i,
                Gender = i%3==0? "Female" : "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person{
                Id = 1,
                FirstName = "Fulano",
                LastName = "Silva",
                Address = "",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}