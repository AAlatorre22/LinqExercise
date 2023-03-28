using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");
            Console.WriteLine();

            //TODO: Print the Average of numbers

            Console.WriteLine($"Average of numbers: {numbers.Average()}");
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Numbers in ascending order: ");
            numbers.OrderBy(x => x).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine();
            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("Numbers in descending order: ");
            var descending = numbers.OrderByDescending(x => x);
            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers above 6:");
            numbers.Where( x => x > 6).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            Console.WriteLine("Only 4 numbers in list:");
            var only4 = numbers.Take(4).OrderByDescending(x => x);
            foreach (var num in only4)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("Added my old age and ordered in descending order:");
            numbers.SetValue(32, 4);
            var age = numbers.OrderByDescending(x => x); //.ToList().ForEach(Console.WriteLine);
            foreach (var x in age)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();



            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a
            //C OR an S and order this in ascending order by FirstName.

            var startsWith = employees.Where(name => name.FirstName.ToLower().StartsWith("c") ||
            name.FirstName.ToLower()[0] == 's').OrderBy(name => name.FirstName);
            Console.WriteLine("Name starts with C or S");
            Console.WriteLine();
            startsWith.ToList().ForEach(x => Console.WriteLine(x.FullName));
            
            //foreach (var employee in startsWith)
            //{
            //    Console.WriteLine(employee.FullName);
            //}
            
            Console.WriteLine();
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26
            //to the console and order this by Age first and then by FirstName in the same result.

            var over26 = employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);
           
            Console.WriteLine("Greater than 26:");
            Console.WriteLine();
            foreach (var employee in over26)
            {
                Console.WriteLine($"Name: {employee.FullName}");
                Console.WriteLine($"Age: {employee.Age}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees'
            //YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var yoe = employees.Where(yoe => yoe.YearsOfExperience <= 10 && yoe.Age > 35);

            Console.WriteLine($"Sum of YOE: {yoe.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average of YOE: {yoe.Average( x => x.YearsOfExperience)}");
            Console.WriteLine();
            Console.WriteLine();


            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Hired new employee and added to list");
            employees = employees.Append(new Employee("Alejandro", "Alatorre", 32, 1)).OrderBy(x => x.FirstName).ToList();
            Console.WriteLine();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

            Console.WriteLine();
            
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
