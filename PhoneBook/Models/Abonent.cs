using System;
namespace PhoneBook.Models
{
    public class Abonent
    {
        public readonly string Name;
        public readonly PhoneNumber PhoneNumber;
        
        public Abonent(string Name,PhoneNumber PhoneNumber) 
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }

        public override string ToString()
        {
            return $"Name: {Name} | PhoneNumber {PhoneNumber.ToString()}";
        }

    }

}

