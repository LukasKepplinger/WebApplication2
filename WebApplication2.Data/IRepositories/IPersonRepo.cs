using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data.IRepositories
{
    public interface IPersonRepo
    {
        Task<List<Person>> GetAll();
        Task<List<Person>> GetAllByFirstName(string name);
        Task<Person> GetById(int id);   
        Task<Person> GetByFirstName(string name);
        Task Insert(Person person);
        Task Update(Person person);
        Task Delete(int id);
    }
}
