using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareentwicklung.TechnicalSkills.Domain.ValueObjects
{
    //Is a record because this object is unalterable and depends from de value
    public record PersonId
    {
        public Guid value { get; init; } 

        //Constructor
        internal PersonId(Guid value_) 
        { 
            value = value_;
        }

        //Create the value type PersonId
        public static PersonId create(Guid value)
        {
            return new PersonId(value);
        }

        //Make the conversion from PersonId to Guid
        public static implicit operator Guid(PersonId personId)
        {
            return personId.value; 
        }
    }
}
