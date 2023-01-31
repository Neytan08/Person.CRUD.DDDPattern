using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.Repositories
{
    public interface PersonRepository
    {
        //Operations to  Person
        Task<Person> GetPersonById(PersonId Id);

        Task AddPerson(Person person);

        Task<List<Person>> GetAllPerson();

    }
}
