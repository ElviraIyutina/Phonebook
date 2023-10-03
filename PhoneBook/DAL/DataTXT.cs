using System;
using PhoneBook.Models;
using System.IO;

namespace PhoneBook.DAL
{
    public class DataTXT
    {
        const string PATH = @"/Users/alex/Projects/PhoneBook/PhoneBook/Data/PhonebookDB.txt";
        public DataTXT()
        {

            string fileText = File.ReadAllText(PATH);
            Console.WriteLine(fileText);

        }

        public static void AddAbonent(Abonent Abonent)
        {
            string result = "";
            result += Abonent.Name;
            result += ";";
            result += (int)Abonent.PhoneNumber.CountryCode;
            result += ";";
            result += Abonent.PhoneNumber.Number;
            result += "\n";
            File.AppendAllText(PATH, result);
        }

        public static List<Abonent> LoadData()
        {
            List<Abonent> abonents = new List<Abonent>();

            string strAllAbonents = File.ReadAllText(PATH);

            List<string> strAbonents = strAllAbonents.Split("\n").ToList();
            foreach(var abonent in strAbonents)
            {
                List<string> strAbonent = abonent.Split(";").ToList();
                if(strAbonent.Count==3)
                {
                    abonents.Add(new Abonent(strAbonent[0], new PhoneNumber((CountryCodes)Int32.Parse(strAbonent[1]), UInt64.Parse(strAbonent[2]))));
                }
            }
            return abonents;
        }

        public static void UploadData(List<Abonent> Abonents)
        {
            string result = "";
            foreach(var abonent in Abonents)
            {
                result += abonent.Name;
                result += ";";
                result += (int)abonent.PhoneNumber.CountryCode;
                result += ";";
                result += abonent.PhoneNumber.Number;
                result += "\n";
            }
            File.WriteAllTextAsync(PATH, result);
        }
    }
}

