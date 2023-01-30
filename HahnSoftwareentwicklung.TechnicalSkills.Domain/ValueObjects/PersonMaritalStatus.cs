using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects
{
    public  record PersonMaritalStatus
    {
        public string Value { get; set; }

        internal PersonMaritalStatus(string value)
        {
            this.Value = value;
        }

        //Method to encapsulate the ObjectValue PersonMaritalStatus to class Person
        public static PersonMaritalStatus Create(string value)
        {
            validate(value);
            return new PersonMaritalStatus(value);
        }

        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("The marital status can't be null");
            }
        }
    }
}
