using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    public class Modelfirstclass
    {
        Model1 dc=new Model1();
        public void Insertorder()
        {
            Pizza p = new Pizza()
            {
                PizzaId=1,
                PizzaName="Corn Pizza",
                Description="made with cheeze",
                Type="Regular",
                price=250,
            };
            dc.Pizzas.Add(p);
            int i=dc.SaveChanges();
            Console.WriteLine("Adding one record "+ i);

            //for showing record
            foreach(var item in dc.Pizzas)
            {
                Console.WriteLine($"{item.PizzaId},{item.PizzaName},{item.price},{item.Type}");
            }
        }
        static void Main(string[] args)
        {
            Modelfirstclass dc1 = new Modelfirstclass();
            dc1.Insertorder();
        }
    }
}
