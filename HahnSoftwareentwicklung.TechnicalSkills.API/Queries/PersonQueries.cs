using HahnSoftwareentwicklung.TechnicalSkills.API.Commands;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Repositories;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;
using System.ComponentModel;

namespace HahnSoftwareentwicklung.TechnicalSkills.API.Queries
{
    public class PersonQueries
    {
        private readonly PersonRepository personRepository;

        public PersonQueries(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<Person> GetPersonIdAsync(Guid id)
        {
            var respose = await personRepository.GetPersonById(
                PersonId.create(id));
            return respose;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            var respose = await personRepository.GetAllPerson();
            return respose;
        }
        public async Task<Person> DeletePersonIdAsync(Guid id)
        {
            var respose = await personRepository.DeletePersonIdAsync(PersonId.select(id));

            return respose;
        }

        public async Task UpdatePerson(Guid id, Person person)
        {
            await personRepository.UpdatePerson(PersonId.select(id), person);
        }
    }
}
