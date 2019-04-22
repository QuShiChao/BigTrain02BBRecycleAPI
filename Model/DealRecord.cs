using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    //交易记录
    public class DealRecord
    {
        [Key]
        public int Did { get; set; }
        public DateTime Dtime { get; set; }
        public decimal Dmoney { get; set; }
        public string Oid { get; set; }
        public int Cid { get; set; }
        public int Uid { get; set; }
    }
}
