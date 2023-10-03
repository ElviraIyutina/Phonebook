using System;
using System.Xml.Linq;
using PhoneBook.Models;
using PhoneBook.DAL;
namespace PhoneBook.BLL
{
    public class Phonebook
    {
        public List<Abonent> Abonents { get; private set; }
        public void CreateAbonent(Abonent Abonent)
        {
            if (FindByName(Abonent.Name)!= null)
            {
                throw new Exception("the abonent is already exist");
            }
            if (FindByPhoneNumber(Abonent.PhoneNumber)!= null)
            {
                throw new Exception("the abonent is already exist");
            }
            Abonents.Add(Abonent);
            DataTXT.AddAbonent(Abonent);
        }
        public void DeleteAbonentByName(string Name)
        {
            Abonent? abonent = FindByName(Name);
            if(abonent != null)
            {
                Abonents.Remove(abonent);
                DataTXT.UploadData(Abonents);
                return;
            }
            throw new Exception("Abonent not found");
        }
        public void DeleteAbonentByPhoneNumber(PhoneNumber PhoneNumber)
        {
            Abonent? abonent = FindByPhoneNumber(PhoneNumber);
            if (abonent != null)
            {
                Abonents.Remove(abonent);
                DataTXT.UploadData(Abonents);
                return;
            }
            throw new Exception("Abonent not found");
        }
        public Abonent? FindByName(string Name)
        {
            foreach (var abonent in Abonents)
            {
                if (abonent.Name == Name)
                {
                    return abonent;
                }
                
            }
            return null;
        }
        public Abonent? FindByPhoneNumber (PhoneNumber PhoneNumber)
        {
            foreach (var abonent in Abonents)
            {
                if (abonent.PhoneNumber.Number == PhoneNumber.Number && abonent.PhoneNumber.CountryCode == PhoneNumber.CountryCode)
                {
                    return abonent;
                }

            }
            return null;
        }
        public Phonebook()
        {
            Abonents = DataTXT.LoadData();
        }
    }
}

