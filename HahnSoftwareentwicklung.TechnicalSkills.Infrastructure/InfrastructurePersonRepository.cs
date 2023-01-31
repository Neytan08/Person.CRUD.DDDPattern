using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Repositories;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Infrastructure
{
    public class InfrastructurePersonRepository : PersonRepository
    {
        DatabaseContext db;
        private readonly IList<Person> _persons;

        public InfrastructurePersonRepository(DatabaseContext db_)
        {
            db = db_;
            _persons= new List<Person>();
        }

        public async Task AddPerson(Person person)
        {
            await db.AddAsync(person);
            await db.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPerson()
        {
            return await db.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(PersonId Id)
        {
            //Make the conversion of personId to Guid
            return await db.Persons.FindAsync((Guid)Id);
        }
    }
}
