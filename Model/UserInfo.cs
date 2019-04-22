using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Uname { get; set; }
        public string Upwd { get; set; }
        public string Usex { get; set; }
        public int Uage { get; set; }
        public string Utel { get; set; }
        public string Uimage { get; set; }
        public string Uaddr { get; set; }
        public int Unum { get; set; }
        public decimal Udealmoney { get; set; }
        public string Ubankcard { get; set; }
        public string UalipayCode { get; set; }
        public string UwechatCode { get; set; }
    }
}
