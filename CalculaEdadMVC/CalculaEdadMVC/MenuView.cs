using System;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using static System.Net.Mime.MediaTypeNames;

namespace CalculaEdadMVC
{
    public class MenuView
    {
        public void ShowWelcome()
        {
            Console.WriteLine("\n ---- Bienvenido ---- \n");
        }

        public string GetNameInput()
        {
            Console.Write("\nIndique su nombre: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
                return name;
            else
            {
                Console.WriteLine("\nEscriba algo.");
                return GetNameInput();
            }
        }


        public int ShowMenu(string name)
        {
            Console.WriteLine($"\nBienvenido {name}, que desea hacer?");
            Console.WriteLine("\n1. Saber la edad en la fecha actual.");
            string text = Console.ReadLine();

            if (!int.TryParse(text, out int opcion))
            {
                Console.WriteLine("\nEscriba algo válido.");
                return ShowMenu(name);
            }
            return opcion;
        }

        public DateTime ShowBirthDate(string name)
        {
            bool isDateTime;
            DateTime birth;
            do
            {
                Console.Write($"\n{name}, Indique su fecha de nacimiento (dd/mm/aaaa): ");
                string birthDate = Console.ReadLine();
                if (DateTime.TryParseExact(birthDate, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out birth))
                {
                    birth = DateTime.Parse(birthDate);
                    isDateTime = true;
                }
                else
                    isDateTime = false;

                if (birth.Year > DateTime.Now.Year)
                    isDateTime = false;

            } while (!isDateTime);

            return birth;

        }

        public int ShowBirthFormat(string name)
        {
            int opcion;
            Console.WriteLine($"\nQue formato desea, {name}?: ");
            Console.WriteLine("1. Año, mes, dia. ");
            Console.WriteLine("2. Año");
            string text = Console.ReadLine();
            if (!int.TryParse(text, out opcion))
                return ShowBirthFormat(name);
            return opcion;

        }

        public void ShowAgeMonthDay(int years, int months, int days)
        {
            Console.WriteLine("\nAños: " + years + ", Meses: " + months + ", Dias: " + days);
        }

        public void ShowAge(int years)
        {
            Console.WriteLine("\nAños: " + years);
        }
       
    }
}
