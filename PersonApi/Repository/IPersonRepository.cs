using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Models;


namespace PersonApi.Repository
{
    public interface IPersonRepository
    {       
        Task<IEnumerable<Person>> Get();
        Task<Person> Get(int code);
        Task<Person> Create(Person person);
        Task Update(Person person);
        Task Delete(int code);
       
    }
}
