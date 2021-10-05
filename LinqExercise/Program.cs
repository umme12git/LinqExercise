using System;
using System.Collections.Generic;
using System.Linq;

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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sumOfNumbers = numbers.Sum(sum => sum);
            var avgOfNumbers = numbers.Average(num => num);
            Console.WriteLine($"Sum of numbers is {sumOfNumbers}, Average of numbers is {avgOfNumbers}");


            //Order numbers in ascending order and decsending order. Print each to console.

            var ascNumbers = numbers.OrderBy(num => num);
            foreach (var num in ascNumbers)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            var desNumbers = numbers.OrderByDescending(num => num);
            foreach (var num in desNumbers)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();


            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.Write($"Greater than six ");
            foreach (var num in greaterThanSix)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();


            var checkTake = numbers.Take(4);
            Console.WriteLine("****");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var ascListFour = numbers.OrderBy(num => num).Take(4);

            Console.WriteLine("First four numbers in ascending");
            foreach (var num in ascListFour)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            //numbers[3] = 52;
            // var changedNumbers = numbers.ToList();
            //Change the value at index 4 to your age, then print the numbers in decsending order
            var changedNumbers = numbers.Select(num => { numbers[3] = 52; return num; }).OrderByDescending(num => num);
            Console.WriteLine("Changed number list");
            foreach (var num in changedNumbers)
            {
                Console.Write($"{num} ");
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();
            Console.WriteLine();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            //Console.WriteLine(employees[0].FirstName);
            var empFirstWithCOrS = employees.Where<Employee>((fName =>
                                   fName.FirstName.Substring(0, 1) == "C" ||
                                   fName.FirstName.Substring(0, 1) == "S")).
                                   OrderBy(fName => fName.FirstName).ToList();

            //Console.WriteLine(empFirstWithCOrS[1].FullName);
            Console.WriteLine("Employees full name with first letter of first name is C or S");
            Console.WriteLine();
            foreach (var name in empFirstWithCOrS)
            {
                Console.WriteLine(name.FullName);
            }
            Console.WriteLine();

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var empAgeOver = employees.Where<Employee>(ageOver => ageOver.Age > 26).
                              OrderBy(ageOver => ageOver.FirstName).
                              OrderBy(ageOver => ageOver.Age).ToList();

            Console.WriteLine("Names of people whose age is over 26");
            Console.WriteLine();
            foreach (var emp in empAgeOver)
            {
                Console.WriteLine($"{emp.FullName}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            //Add an employee to the end of the list without using employees.Add()

            var sumOfYearsExp = employees.Sum(sum => sum.YearsOfExperience);
            var avgOfYearsExp = employees.Average(avg => avg.YearsOfExperience);
            Console.WriteLine($"Sum of years of experience of employees  {sumOfYearsExp}");
            Console.WriteLine($"Average years of experience of employees  {avgOfYearsExp}");

            var newEmployee = employees.Where<Employee>(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).
                             Append(new Employee("Kristen", "Molan", 38, 7)).ToList();


                foreach(var person in newEmployee)
                    Console.WriteLine(person.FirstName);

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
