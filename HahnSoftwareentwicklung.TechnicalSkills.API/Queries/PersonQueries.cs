using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Repositories;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;

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

        public async Task<Person> GetAllPerson()
        {
            var respose = await personRepository.GetAllPerson();
            return respose;
        }
    }
}
