using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityPractice
{
    internal class CRUDCLASS
    {
        dbo_dbEntities1 db1 = new dbo_dbEntities1();

        public void showemployee()
        {
            //it should display all employee

            var res = from e in db1.Employees select e;
            foreach(var e in res)
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary}");
                Console.WriteLine("------------------------------------------------------------");
            }
        }
        public void searchrecord()
        {
            var res = from e in db1.Employees
                      where e.EmpName.Contains("e") select e;
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary}");
                Console.WriteLine("------------------------------------------------------------");
            }

        }
        public void Addrecord()
        {
            //create object of the table which you want to add(employee)

            // step 1 initialize the properties
           
            Employee eob= new Employee() { EmpName="Rakesh",Salary=340000,DateOfJoin=DateTime.Parse("2025-01-01"),DeptID=10};

            //step 2 attach the object to property

            db1.Employees.Add(eob);

            //step 3 update the change to database

            int i = db1.SaveChanges(); //update all change to database

            Console.WriteLine($"Total rows updated : {i}");

        }
        public void Removerecord()
        {
            //step 1 search record u want to remove

            Console.WriteLine("Enter empid for removed");
            int eid=int.Parse(Console.ReadLine());

            var res = (from e in db1.Employees
                      where e.EmpID == eid
                      select e).First();

            // step 2 remove that row from table

            db1.Employees.Remove(res);

            //update the changes in database

            int i = db1.SaveChanges();

            Console.WriteLine($"Total rows deleted : {i}");

            Console.WriteLine($"{res.EmpID},{res.EmpName},{res.DateOfJoin},{res.Salary},{res.DeptID}");
            Console.WriteLine("------------------------------------------------------------------------");
        }
        public void updaterecord()
        {
            // step 1
            Console.WriteLine("enter the employee id for update the record");
            int id = int.Parse(Console.ReadLine());

            var res= (from e in db1.Employees
                     where e.EmpID == id select e).First();
            //step 2

            res.Salary = 500000;

            // step 3

            int i = db1.SaveChanges();

            Console.WriteLine($"total rows updated : {i}");
        }

        // Questions

        public void Question1()
        {
            //display matching records of employee and department  from databse

            var res = from e in db1.Employees
                      join d in db1.Departments
                      on e.DeptID equals d.DeptID
                      select new { e.EmpID,e.EmpName,e.DeptID,d.DeptName,e.Salary,e.DateOfJoin };
            foreach( var e in res.ToList() )
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.Salary},{e.DateOfJoin},{e.DeptID},{e.DeptName}");
            }
            
        }

        //Question2

        public void Question2()
        {
            //display empid,empname,deptid, from both table

            var res = from e in db1.Employees
                      join d in db1.Departments
                      on e.DeptID equals d.DeptID
                      select new { e.EmpID, e.EmpName, d.DeptID};
            foreach (var e in res.ToList())
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DeptID}");
            }
        }
        //Question3
        public void Question3()
        {
            //accept two dates from the user dynamically.it should all employee details who joined between 2 dates

            Console.Write("Enter start date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter end date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            var res = from e in db1.Employees
                      where e.DateOfJoin >= startDate && e.DateOfJoin <= endDate
                      select e;

            foreach ( var e in res.ToList())
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.Salary},{e.DateOfJoin},{e.DeptID}");

            }
        }

        //Question4
        public void Question4()
        {
            //display empid,empname,salary,and sal with bonus 30%

            var res = from e in db1.Employees
                      select new
                      {
                          e.EmpID,
                          e.EmpName,
                          e.Salary,
                          SalarywithBonus = e.Salary + (e.Salary * 0.30m)
                      };

            Console.WriteLine("=== Employee Details with Bonus ===");
            foreach (var r in res.ToList())
            {
                Console.WriteLine($"{r.EmpID} | {r.EmpName} | {r.Salary} | {r.SalarywithBonus}");
            }


        }
        //Question5
        public void Question5()
        {
            //peform insert and delete by accepting data from the user dynamically
            Console.WriteLine("Enter Employee Id");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Employee salary");
            int sal = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee join of date");
            DateTime DOJ = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter employee deptid");
            int Did = int.Parse(Console.ReadLine());

            var employee = new Employee()
            {

                EmpID = ID,
                EmpName = Name,
                Salary = sal,
                DateOfJoin = DOJ,
                DeptID = Did,
            };
            db1.Employees.Add(employee);
            db1.SaveChanges();
            Console.WriteLine("Employee inserted new employee id is " + employee.EmpID);

            //code for deleted record
            Console.WriteLine("Enter Employee id for removing record");
            int Eid=int.Parse(Console.ReadLine());
            var res = (from e in db1.Employees
                       where e.EmpID == Eid
                       select e).First();

            db1.Employees.Remove(res);
            db1.SaveChanges();
            Console.WriteLine("Employee deleted employee id "+res.EmpID);
                    
        }

        // How we write sql query in entity framework

        public void sqlquery()
        {
            //how to write sql query
            //use this query only for display record

            var res = db1.Database.SqlQuery<Employee>("select * from Employee where empname like 'm%'");
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary}");
                Console.WriteLine("------------------------------------------------------------");
            }

        }
        //this is for delete update means DML command only

        
        public void DMLDemo()
        {
            //connected Architecture

            //for update and insert and delete use this
            int row = db1.Database.ExecuteSqlCommand("delete from Employee where empname like 'ra%'");
            Console.WriteLine("total deleted row : " + row);
        }
        //how we can call procedures
        public void sp()
        {
            //how to call procedures
            //we can use procedure when we using joins and subqueries
            var res = db1.searchbysal(600000);
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary}");
                Console.WriteLine("------------------------------------------------------------");
            }

        }

        //we can extract employee details using department , and department record using employee

        public void sqlquery1()
        {
            //how to write sql query
            //use this query only for display record

            var res = db1.Database.SqlQuery<Employee>("select * from Employee where empname like 'm%'");
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary},{e.Department.DeptName},{e.Department.DeptID}");
            }

        }
        public void sqlquery2()
        {
            //how to write sql query
            //use this query only for display record

            var res = db1.Database.SqlQuery<Department>("select * from Department");
            foreach (var d in res)
            {
                Console.WriteLine($"{d.DeptName},{d.DeptID}");
                foreach(var e in d.Employees)
                {
                    Console.WriteLine($"{e.EmpID},{e.EmpName},{e.DateOfJoin},{e.DeptID},{e.Salary}");

                }
            }

        }


        static void Main(string[] args)
        {
            CRUDCLASS cc=new CRUDCLASS();
            //Question1
            //Console.WriteLine("All employee record:\n");
            //cc.showemployee();

            ////Question2
            //Console.WriteLine("\nShow filter employee:");
            //cc.searchrecord();

            ////QUestion3
            //Console.WriteLine("\nAdded record");
            //cc.Addrecord();

            ////Question4
            //Console.WriteLine("\nremoved record");
            //cc.Removerecord();

            ////Question5
            //Console.WriteLine("\nupdated record");
            //cc.updaterecord();

            //QuestionAssign1
            //Console.WriteLine("Matching record :");
            //cc.Question1();

            //QuestionAssign2
            //Console.WriteLine("Some record from both table");
            //cc.Question2();

            //QuestionAssign3
            //Console.WriteLine("print some record which contains between two days");
            //cc.Question3();

            //QuestionAssign4
            //Console.WriteLine("print employess details with salarybouns");
            //cc.Question4();

            //QuestionAssign5
            Console.WriteLine("inserted and deleted record");
            cc.Question5();

            //Console.WriteLine("using sqlquery");
            //cc.sqlquery();

            //Console.WriteLine("usnig DMl");
            //cc.DMLDemo();

            //Console.WriteLine("using storeprocedure");
            //cc.sp();

            //Console.WriteLine("using employee table we can print department details also");
            //cc.sqlquery1();

            //Console.WriteLine("using department table we can print employee details also");
            //cc.sqlquery2();

            Console.ReadLine();

        }
    }
}
