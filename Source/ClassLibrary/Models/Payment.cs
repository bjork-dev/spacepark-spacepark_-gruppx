using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [MaxLength(50)]
        public string User { get; set; }
        public DateTime PayDate { get; set; }
    }
}
