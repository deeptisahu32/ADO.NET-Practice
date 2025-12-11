using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_practice
{
    public class empdet
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int DeptId { get; set; }
    }

    public class dept
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
    internal class LinqClass
    {
        List<empdet> employees = new List<empdet>
        {
         new empdet { EmpId = 1, EmpName = "Aasritha", Salary = 30000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 2 },
         new empdet { EmpId = 2, EmpName = "Akshay", Salary = 32000, DateOfJoin = DateTime.Now.AddYears(-2), DeptId = 2 },
         new empdet { EmpId = 3, EmpName = "Anvith Reddy", Salary = 35000, DateOfJoin = DateTime.Now.AddMonths(-10), DeptId = 3 },
         new empdet { EmpId = 4, EmpName = "ASHOK", Salary = 28000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 1 },
         new empdet { EmpId = 5, EmpName = "Deepalakshmi", Salary = 36000, DateOfJoin = DateTime.Now.AddMonths(-6), DeptId = 4 },
         new empdet { EmpId = 6, EmpName = "Deepti", Salary = 36000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 4 },
         new empdet { EmpId = 7, EmpName = "Dharani sri", Salary = 30000, DateOfJoin = DateTime.Now.AddYears(-3), DeptId = 1 },
         new empdet { EmpId = 8, EmpName = "Humera", Salary = 33000, DateOfJoin = DateTime.Now.AddMonths(-8), DeptId = 2 },
         new empdet { EmpId = 9, EmpName = "Kanishka", Salary = 31000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 3 },
         new empdet { EmpId = 10, EmpName = "KEERTHANA", Salary = 30000, DateOfJoin = DateTime.Now.AddMonths(-4), DeptId = 4 },
         new empdet { EmpId = 11, EmpName = "Keerthi", Salary = 35000, DateOfJoin = DateTime.Now.AddMonths(-5), DeptId = 2 },
         new empdet { EmpId = 12, EmpName = "Keerthickragul", Salary = 36000, DateOfJoin = DateTime.Now.AddYears(-2), DeptId = 3 },
         new empdet { EmpId = 13, EmpName = "Logeshwaran", Salary = 28000, DateOfJoin = DateTime.Now.AddMonths(-9), DeptId = 1 },
         new empdet { EmpId = 14, EmpName = "Madavi", Salary = 30000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 1 },
         new empdet { EmpId = 15, EmpName = "Manikanta", Salary = 31000, DateOfJoin = DateTime.Now.AddMonths(-7), DeptId = 2 },
         new empdet { EmpId = 16, EmpName = "Fatima", Salary = 29000, DateOfJoin = DateTime.Now.AddYears(-3), DeptId = 3 },
         new empdet { EmpId = 17, EmpName = "Nagamani", Salary = 35000, DateOfJoin = DateTime.Now.AddMonths(-6), DeptId = 2 },
         new empdet { EmpId = 18, EmpName = "Pooja", Salary = 30000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 4 },
         new empdet { EmpId = 19, EmpName = "Hymavathi", Salary = 32000, DateOfJoin = DateTime.Now.AddYears(-2), DeptId = 1 },
         new empdet { EmpId = 20, EmpName = "Sairam Somaraju", Salary = 40000, DateOfJoin = DateTime.Now.AddMonths(-9), DeptId = 4 },
         new empdet { EmpId = 21, EmpName = "Sakthivel", Salary = 31000, DateOfJoin = DateTime.Now.AddMonths(-10), DeptId = 2 },
         new empdet { EmpId = 22, EmpName = "Usha sri", Salary = 29000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 3 },
         new empdet { EmpId = 23, EmpName = "Waseef", Salary = 36000, DateOfJoin = DateTime.Now.AddMonths(-3), DeptId = 1 }
        };

        List<dept> departments = new List<dept>
        {
         new dept { DeptId = 1, DeptName = "HR" },
         new dept { DeptId = 2, DeptName = "IT" },
         new dept { DeptId = 3, DeptName = "Finance" },
         new dept { DeptId = 4, DeptName = "Training" }
        };

        //USing LINQ QUERY
        // LINQ WITH ARRAY 
        public void  demo1()
        {
            string[] studentnames = { "Ashritha", "deepa", "Ashok", "sai", "kanishka", "Anvith" };

            //show all name start with A

            var res = from t in studentnames
                      where t.StartsWith("A") || t.Length == 3
                      select t;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        public void Demo2()
        {

            int[] numbers = { 10, 11, 12, 13, 14, 15, 16 };

            // write a linq program to show only even number

            var res = from i in numbers
                      where i % 2 == 0 && i > 12
                      select i;

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

        }

        //LINQ USING LIST
        public void Demo3()
        {

            // arrays, lists, xml, database ....



            //===================================================================
            //write a linq query to display all details where name contains a 'K' 

            var res = from t in employees
                      where t.EmpName.Contains("K")
                      select t;


            foreach (var item in res)
            {
                Console.WriteLine(item.EmpName);
            }

            

           
        }
        public void demo4()
        {
            // write a linq query to display all empid between 8  23 and sort names in descending order


            var res = from t in employees where t.EmpId > 8 && t.EmpId <= 23 orderby t.EmpName descending select t;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.EmpId},{item.EmpName}");
            }
        }
        public void demo5()
        {
            // write a linq query to show only empid , empname, deptid


            var res = from t in employees

                      select new { Employeeid = t.EmpId, Employeename = t.EmpName, departmentid = t.DeptId };

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Employeeid}  {item.Employeename}   {item.departmentid}");
            }

        }
        public void demo6()
        {
            // how many rows are printed ?
            // 5 

            var res = (from t in employees
                       select t);   // this linq query is not executed here // i will print with new rows

            var res1 = (from t in employees
                       select t).ToList(); //through this new rows will not add


            employees.Add(new empdet { EmpId = 9, EmpName = "Kanishka", Salary = 31000, DateOfJoin = DateTime.Now.AddYears(-1), DeptId = 3 });
            employees.Add(new empdet { EmpId = 20, EmpName = "Sairam Somaraju", Salary = 40000, DateOfJoin = DateTime.Now.AddMonths(-9), DeptId = 4 });


            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin}  {item.DeptId}");
            }

            foreach (var item in res1)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin}  {item.DeptId}");
            }
        }

        public void demo7()
        {
            // show me common records from both the table

            // both method work same

            //var res = from t in employees
            //          from t1 in departments
            //          where t.DeptId == t1.DeptId
            //          select new {t.EmpId, t.DeptId,t.EmpName, t.Salary , t1.DeptName };


            var res = from t in employees
                      join t1 in departments
                      on t.DeptId equals t1.DeptId
                      select new { t.EmpId, t.DeptId, t.EmpName, t.Salary, t1.DeptName };



            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DeptId}  {item.DeptName}");
            }
        }

        // now we will write code using lambda

        // most commonly used methods

        // take , skip , takewhile, skipwhile, order by , orderbydescending, thenby,thenbydecending
        public void demo8()
        {
            //how lambda works?


            // query expression method 
            //var res = from t in employees
            //          where t.DeptId==1
            //          select t;


            // lambda expression method


            var res = employees.Where(t => t.DeptId == 1);

            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }


        }
        public void demo9()
        {
            var res = employees.Take(3);// display top 3 records
            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }

        }
        public void demo10()
        {
            var res = employees.Skip(3);//skips 1st 3 rows
            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }
        }

        public void demo11()
        {
            var res = employees.TakeWhile(t => t.Salary != 31000);
            var res1 = employees.SkipWhile(t => t.Salary != 31000);

            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }
            foreach (var item in res1)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }
        }
        public void demo12()
        {
            // supports chaning model


            // every method output will go as an input for next method

            // var res = employees.Take(8).Skip(8).TakeWhile(t => t.Salary > 20000);

            // select top 3 second highest salary 

            //  var res = employees.OrderByDescending(t => t.Salary).Take(4).Skip(1);


            var res = employees.OrderByDescending(t => t.Salary).Skip(1).Take(3);

            foreach (var item in res)// linq query is executed here
            {
                Console.WriteLine($"{item.EmpId}  {item.EmpName}   {item.Salary}  {item.DateOfJoin} {item.DeptId}");
            }
        }
       
        static void Main(string[] args)
            {
                LinqClass linqClass = new LinqClass();

            //linqClass.demo1();

            // linqClass.Demo2();

            //linqClass.Demo3();

            //linqClass.demo4();

            //linqClass.demo5();

            //linqClass.demo6();

            //linqClass.demo7();

            //linqClass.demo8();

            //linqClass.demo9();

            //linqClass.demo10();

            //linqClass.demo11();

            linqClass.demo12();




            Console.ReadLine();
        }

    }
}
