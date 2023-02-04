using HahnSoftwareentwicklung.TechnicalSkills.API.Commands;
using HahnSoftwareentwicklung.TechnicalSkills.API.Queries;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Repositories;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;
using System.Collections;

namespace HahnSoftwareentwicklung.TechnicalSkills.API.ApplicationServices
{
    public class APIServices
    {
        private readonly PersonRepository repository;
        private readonly PersonQueries personQueries;

        public APIServices(PersonRepository repository, PersonQueries personQueries) 
        { 
            
            this.repository = repository; 
            this.personQueries = personQueries;
        }

        public async Task HandleCommandCreate(CreatePersonCommand createPerson)
        {
            var person = new Person(PersonId.create(createPerson.personId));
            person.SetName(PersonName.Create(createPerson.Name));
            person.SetPhone(PersonPhone.Create(createPerson.Phone));
            person.SetAddress(PersonAddress.Create(createPerson.Address));
            person.SetMaritalStatus(PersonMaritalStatus.Create(createPerson.MaritalStatus));
            
            await repository.AddPerson(person);
        }

        public async Task<Person> GetPerson(Guid id)
        {
            return await personQueries.GetPersonIdAsync(id);
        }

        public async Task<List<Person>> GetAllPerson()
        {
           return await personQueries.GetAllPerson();
        }

        public async Task<Person> DeletePerson(Guid id)
        {

           return await personQueries.DeletePersonIdAsync(id);
        }

        public async Task UpdatePerson(Guid id, UpdatePersonCommand updateperson)
        {
            var person = new Person(PersonId.create(updateperson.personId));
            person.SetName(PersonName.Create(updateperson.Name));
            person.SetPhone(PersonPhone.Create(updateperson.Phone));
            person.SetAddress(PersonAddress.Create(updateperson.Address));
            person.SetMaritalStatus(PersonMaritalStatus.Create(updateperson.MaritalStatus));

            await personQueries.UpdatePerson(id, person);
        }

        /*
        public async Task<Person> HandleCommandUpdate(Person updatePerson)
        {
            var person = new Person();
            person.SetName(PersonName.Create(updatePerson.Name.Value));
            person.SetPhone(PersonPhone.Create(updatePerson.Phone.Value));
            person.SetAddress(PersonAddress.Create(updatePerson.Address.Value));
            person.SetMaritalStatus(PersonMaritalStatus.Create(updatePerson.MaritalStatus.Value));

            return await personQueries.UpdatePerson(person);
        }
        */
    }
}
