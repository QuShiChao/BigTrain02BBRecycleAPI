using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Recycles
    {
        [Key]
        public int Rid { get; set; }
        public string Rname { get; set; }
        public int Cid { get; set; }
        public string Rdescribe { get; set; }
        public int Rinventory { get; set; }
    }
}
