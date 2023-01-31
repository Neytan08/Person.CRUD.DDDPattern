﻿using HahnSoftwareentwicklung.TechnicalSkills.API.Commands;
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

        public async Task HandleCommand(CreatePersonCommand createPerson)
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

    }
}
