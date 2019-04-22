using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    //回收员
    public class CollectorInfo
    {
        [Key]
        public int Id { get; set; }
        public string CID { get; set; }
        public string Cname { get; set; }
        public string Cpwd { get; set; }
        public string Clocation { get; set; }
        public string Cimage { get; set; }
    }
}
