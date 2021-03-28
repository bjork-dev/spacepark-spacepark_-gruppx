using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Api;

namespace ClassLibrary
{
    public class Parking
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public decimal MaxLength { get; set; }
        public bool Occupied { get; set; }
        [MaxLength(50)] public string ParkedBy { get; set; }
        [MaxLength(50)] public string ShipName { get; set; }
    }
}
