using System;
namespace PhoneBook.Models
{
    public class PhoneNumber
    {
        public readonly CountryCodes CountryCode;
        public readonly ulong Number;
        public PhoneNumber(CountryCodes CountryCode, ulong Number )
        {
            this.CountryCode = CountryCode;
            if (Number > 999999999 && Number < 10000000000)
            {
                this.Number = Number;
            }
            else
            {
                throw new Exception("Not valid number");
            }
        }
        public override string ToString()
        {
            string result = "";

            string number = Number.ToString();

            result += $"+{(int)CountryCode}({number[0]}{number[1]}{number[2]}){number[3]}{number[4]}{number[5]}-{number[6]}{number[7]}-{number[8]}{number[9]}"; 

            return result;
        }
    }
}

