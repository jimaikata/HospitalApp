using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HospitalApp
{
    class Program
    {
        const string filePath = "HospitalEmployees.txt";

        private static List<Employees> LoadInfo()
        {
            List<Employees> employees = new List<Employees>();

            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split('|');

                    if (entries.Length >= 5)
                    {
                        Employees newEmployee = new Employees();

                        newEmployee.FirstName = entries[0];
                        newEmployee.MiddleName = entries[1];
                        newEmployee.LastName = entries[2];
                        newEmployee.Specialization = entries[3];
                        newEmployee.EGN = entries[4];

                        employees.Add(newEmployee);
                    }

                }
            }

            return employees;
        }

        public static void AddDoctor(List<Employees> employees)
        {
            //Console.WriteLine("FirstName|MiddleName|LastName|Specialization|EGN");
            //string[] line = Console.ReadLine().Split('|');
            //string firstName = line[0];
            //string middleName = line[1];
            //string lastName = line[2];
            //string specialization = line[3];
            //string EGN = line[4];

            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Middle Name:");
            string middleName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Specialization:");
            string specialization = Console.ReadLine();

            Console.WriteLine("EGN:");
            string EGN = Console.ReadLine();

            if (EGN.All(char.IsDigit) && EGN.Length == 10 && firstName.All(char.IsLetter) && middleName.All(char.IsLetter) && lastName.All(char.IsLetter))
            {
                employees.Add(new Employees { FirstName = firstName, MiddleName = middleName, LastName = lastName, Specialization = specialization, EGN = EGN });
                Console.WriteLine("Employee Successfully Added");
            }
            else
            {
                Console.WriteLine("Invalid Data");
            }
        }

        public static void SearchWithEGN(List<Employees> employees)
        {
            Console.WriteLine("EGN:");
            string line = Console.ReadLine();

            foreach (var emp in employees)
            {
                if (emp.EGN == line)
                {
                    Console.WriteLine($"(Name: {emp.FirstName} {emp.MiddleName} {emp.LastName}) (Specialization: {emp.Specialization}) (EGN: {emp.EGN})");
                }
            }
        }


        private static void SaveInfo(List<Employees> employees)
        {
            List<string> output = new List<string>();

            foreach (var employee in employees)
            {
                output.Add($"{employee.FirstName}|{employee.MiddleName}|{employee.LastName}|{employee.Specialization}|{employee.EGN}");
            }

            File.WriteAllLines(filePath, output);
        }

        static void Main(string[] args)
        {
            List<Employees> employees = LoadInfo();

            char x;

            while (true)
            {

                Console.WriteLine("1. Add a new doctor");
                Console.WriteLine("2. Search using EGN");
                Console.WriteLine("3. Exit");
                x = char.Parse(Console.ReadLine());

                if (x == '1')
                {
                    AddDoctor(employees);
                }

                else if (x == '2')
                {
                    SearchWithEGN(employees);
                }

                else if (x == '3')
                {
                    break;
                }
                else Console.WriteLine("Invalid number");

                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Console.Clear();
            }

            SaveInfo(employees);
           
        }
    }
}
