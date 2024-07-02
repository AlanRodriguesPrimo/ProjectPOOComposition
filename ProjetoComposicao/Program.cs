using ProjetoComposicao.Entities;
using ProjetoComposicao.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level(Junior/MidLevel/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Enter base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter "+ i + " contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour =  double.Parse(Console.ReadLine());
                Console.Write("Duration(Hours): ");
                int hour = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date,valuePerHour,hour);
                worker.AddContract(contract);
                Console.WriteLine();
            }

                Console.WriteLine();
                Console.Write("Enter month and year to calculate income (MM/YYYY): ");
                string monthAndYear = Console.ReadLine();
                int month = int.Parse(monthAndYear.Substring(0, 2));
                int year = int.Parse(monthAndYear.Substring(3));
                Console.WriteLine("Name: " + worker.Name);
                Console.WriteLine("Department: " + worker.Department.Name);
                Console.WriteLine("Income for "+ monthAndYear + " : "+ worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

                Console.WriteLine("Finalizado !!!");
                string parar = Console.ReadLine();
                
        }
    }
}
