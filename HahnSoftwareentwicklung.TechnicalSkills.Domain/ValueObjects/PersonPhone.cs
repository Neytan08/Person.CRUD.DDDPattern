using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects
{
    public record class PersonPhone
    {
        public int Value { get; set; }

        internal PersonPhone(int value)
        {
            this.Value = value;
        }
        //Method to encapsulate the ObjectValue PersonPhone to class Person
        public static PersonPhone Create(int value)
        {
            validate(value);
            return new PersonPhone(value);
        }

        private static void validate(int value)
        {
            if (value == 0)
            {
                throw new ArgumentException("The phone can't be null");
            }
        }
    }
}
