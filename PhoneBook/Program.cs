using PhoneBook.DAL;
using PhoneBook.Models;
using PhoneBook.BLL;
using System.Xml.Linq;

namespace PhoneBook
{
    public class Program
    {
        public static Phonebook phonebook = new Phonebook();

        public static void Main()
        {
            while(true)
            {
                Menu();
            }
            
        }

        private static void Menu()
        {
            Console.WriteLine("Нажмите: \n1 - чтобы вывести всех абонентов\n2 - добавить абонента \n3 - найти абонента по имени\n4 - найти абонента по номеру\n5 - удалить абонента по имени\n6 - удалить абонента по номеру телефона");
            switch(Console.ReadLine())
            {
                case "1":
                    WriteAllAbonents();
                    break;
                case "2":
                    AddAbonent();
                    break;
                case "3":
                    FindAbonentByName();
                    break;
                case "4":
                    FindAbonentByPhoneNumber();
                    break;
                case "5":
                    DeleteAbomemtByName();
                    break;
                case "6":
                    DeleteAbonentByPhoneNumber();
                    break;
                default:
                    Console.WriteLine("Введена неправильная цифра");
                    break;
            }
        }
        private static void WriteAllAbonents()
        {
            foreach(var abonent in phonebook.Abonents)
            {
                Console.WriteLine(abonent.ToString());
            }
        }
        private static void AddAbonent()
        {
            Console.WriteLine("Введите имя абонента:");
            string name = Console.ReadLine() ?? "";
            string phoneNumber = "";
            string number = "";
            string contryCode = "";
            while (phoneNumber.Length < 11)
            {
                Console.WriteLine("Введите номер телефона:");
                phoneNumber = Console.ReadLine() ?? "";
                number = phoneNumber[(phoneNumber.Length - 10)..];
                contryCode = phoneNumber[1..(phoneNumber.Length - 10)];
                if (phoneNumber.Length < 11)
                {
                    Console.WriteLine("Введен неправильный номер");
                }
            }

            phonebook.CreateAbonent(new Abonent(name, new PhoneNumber((CountryCodes)Int32.Parse(contryCode), UInt64.Parse(number))));

        }
        private static void FindAbonentByName()
        {
            Console.WriteLine("Введите имя абонента:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine(phonebook.FindByName(name)?.ToString() ?? "Абонент не найден");
        }
        private static void FindAbonentByPhoneNumber()
        {
            Console.WriteLine("Введите номер телефона:");
            string phoneNumber = Console.ReadLine() ?? "";
            if(phoneNumber.Length>11)
            {
                string number = phoneNumber[(phoneNumber.Length - 10)..];
                string contryCode = phoneNumber[1..(phoneNumber.Length - 10)];
                Console.WriteLine(phonebook.FindByPhoneNumber(new PhoneNumber((CountryCodes)Int32.Parse(contryCode), UInt64.Parse(number)))?.ToString() ?? "Абонент не найден");
            }
            else
            {
                Console.WriteLine("Введен неправельный номер");
            }
        }
        private static void DeleteAbomemtByName()
        {
            Console.WriteLine("Введите имя абонента:");
            string name = Console.ReadLine() ?? "";
            phonebook.DeleteAbonentByName(name);
        }
        private static void DeleteAbonentByPhoneNumber()
        {
            Console.WriteLine("Введите номер телефона:");
            string phoneNumber = Console.ReadLine() ?? "";
            if (phoneNumber.Length > 11)
            {
                string number = phoneNumber[(phoneNumber.Length - 10)..];
                string contryCode = phoneNumber[1..(phoneNumber.Length - 10)];
                phonebook.DeleteAbonentByPhoneNumber(new PhoneNumber((CountryCodes)Int32.Parse(contryCode), UInt64.Parse(number)));
            }
            else
            {
                Console.WriteLine("Введен неправельный номер");
            }
        }
    }
}