using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects
{
    public record PersonAddress
    {
        public string Value { get; set; }

        internal PersonAddress(string value)
        {
            this.Value = value;
        }

        //Method to encapsulate the ObjectValue PersonAddress to class Person
        public static PersonAddress Create(string value)
        {
            validate(value);
            return new PersonAddress(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("The address can't be null");
            }
        }
    }
}
