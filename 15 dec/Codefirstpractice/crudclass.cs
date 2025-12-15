using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirstpractice
{
    internal class crudclass
    {
        Model1 dc = new Model1();
        public void Showdata()
        {
            var res = from t in dc.ipls select t;
            foreach (var item in res)
            {
                Console.WriteLine($"{item.TeamID},{item.TeamName},{item.Captain},{item.state}");
            }
        }

        //table will genrate automattecly when w run that method which contains savechange

        public void insert()
        {
            IPLCLASS ob = new IPLCLASS() { TeamID = 1, TeamName = "RCB", Captain = "Virat", state = "Karnatak" };
            dc.ipls.Add(ob);
            int i = dc.SaveChanges();
            Console.WriteLine($"inerted rows number " + i);
        }
        static void Main(string[] args)
        {
            crudclass ob = new crudclass();
            ob.insert();

            crudclass1 crudclass1 = new crudclass1();
            crudclass1.insertnewstudent();

            Console.ReadLine();

        }
        
    }
}
