using System;
using System.Data.Entity;
using System.Linq;

namespace Codefirstpractice
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
     

        public virtual DbSet<IPLCLASS> ipls { get; set; }
        public virtual DbSet<Student> students { get; set; }

    }

}