using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirstpractice
{
    internal class crudclass1
    {
        Model1 dc = new Model1();
        public void insertnewstudent()
        {
            try
            {
                Student student = new Student()
                {
                    stuid = 1,
                    name = "Pooja",
                    DOB = DateTime.Now,
                    Class = 9,
                    Email = "pooja@gmail.com"
                };
                dc.students.Add(student);
                int res = dc.SaveChanges();
                Console.WriteLine(res);

            }
            catch (Exception ex)
            {
                var res = dc.GetValidationErrors();

                foreach (var item in res)
                {
                    if (item.ValidationErrors.Count > 0)
                    {
                        foreach (var err in item.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                }
            }
        }
        
    }
}
