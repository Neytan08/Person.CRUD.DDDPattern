using HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; init; }

        //Make the entitie name an valueObject
        //It is a property from Person
        public PersonName Name { get; private set; }
        public PersonPhone Phone { get; private set; }

        public Person(Guid id) 
        { 
            this.Id = id;
        }

        public void SetName(PersonName name)
        {
            Name = name;
        }

        public void SetPhone(PersonPhone phone)
        {
            Phone = phone;
        }
    }
}
