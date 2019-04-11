using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class AdminInfo
    {
        [Key]
        public int Id { get; set; }
        public string Aname { get; set; }
        public string Apwd { get; set; }
        public string Aimage { get; set; }
    }
}
