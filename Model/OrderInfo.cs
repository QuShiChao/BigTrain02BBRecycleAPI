using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class OrderInfo
    {
        [Key]
        public string Oid { get; set; }
        public string Oname { get; set; }
        public int Cid { get; set; }
        public int Onum { get; set; }
        public int Uid { get; set; }
        public int Collector_Id { get; set; }
        public int Owithdraw { get; set; }
        public double Omoney { get; set; }
        public DateTime Otime { get; set; }
        public int Ostatus { get; set; }
    }
}
