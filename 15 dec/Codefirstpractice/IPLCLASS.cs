using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirstpractice
{
    public class IPLCLASS
    {
        //this used for creating primary key
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Captain { get; set; }
        public string state { get; set; }
    }
}
