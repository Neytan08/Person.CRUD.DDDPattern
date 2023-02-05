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

        public InfrastructurePersonRepository(DatabaseContext db_)
        {
            db = db_;
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

        public async Task<Person> DeletePersonIdAsync(PersonId Id)
        {
            var result = await db.Persons
             .FirstOrDefaultAsync(e => e.Id == Id);

            if (result != null)
            {
                db.Persons.Remove(result);
                await db.SaveChangesAsync();

                return result;
            }
            return null;
        }
        
        public async Task UpdatePerson(PersonId id, Person person)
        {
            var result = await db.Persons.FindAsync((Guid)id);
            result.SetName(PersonName.Create(person.Name.Value));
            result.SetPhone(PersonPhone.Create(person.Phone.Value));
            result.SetAddress(PersonAddress.Create(person.Address.Value));
            result.SetMaritalStatus(PersonMaritalStatus.Create(person.MaritalStatus.Value));

            db.Persons.Update(result);
            await db.SaveChangesAsync();
        }
    }
}
