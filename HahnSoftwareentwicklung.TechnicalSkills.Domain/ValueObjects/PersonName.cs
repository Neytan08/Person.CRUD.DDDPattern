using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects
{
    //Is a record because this object is unalterable and depends from de value
    public record PersonName
    {
        public string Value { get; set; }

        internal PersonName(string value) 
        {
            this.Value = value;
        }

        //Method to encapsulate the ObjectValue PersonName to class Person
        public static PersonName Create(string value)
        {
            validate(value);
            return new PersonName(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("The name can't be null");
            }
        }
    }
}
