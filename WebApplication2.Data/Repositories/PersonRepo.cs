using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data.IRepositories;
using WebApplication2.Models;

namespace WebApplication2.Data.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        public PersonRepo(MyDbContext context)
        {
            Context = context;
        }

        public MyDbContext Context { get; }

        public async Task Delete(int id)
        {
            var person = await Context.Persons.FindAsync(id); //?? for Exceptions
            Context.Persons.Remove(person);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAll()
        {
            return Context.Persons.ToList();
        }

        public async Task<List<Person>> GetAllByFirstName(string name)
        {
            return await Context.Persons
                .Where(p => p.FirstName == name)
                .ToListAsync();
        }

        //FirstOrDefault returns a person as soon as it finds one
        //If there is a second person it will be ignored
        //if u want to make sure there is only one person like spezified, use SingleOrDefault 
        //(slower because it checks all entries)
        public async Task<Person> GetByFirstName(string name)
        {
            return await Context.Persons
                .FirstOrDefaultAsync(p => p.FirstName == name);
        }

        public async Task<Person> GetById(int id)
        {
            return await Context.Persons.FindAsync(id);
        }

        //It is common to also return the new entry after Insert/Update/Delete
        //It wont affect performance if u just dont take the return value when calling the Repo Method
        //U often need the id afterwards and after saving the id was written in the person object
        public async Task Insert(Person person)
        {
            await Context.Persons.AddAsync(person);
            await Context.SaveChangesAsync();
        }

        //If possible use Attach instead of Context.Persons.Update
        //Attach is only replacing properties which have changed or just those u want to change (not null)
        //Update replaces everything (worse in performence)
        public async Task Update(Person person)
        {
            var context = Context.Persons.Attach(person);
            context.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
