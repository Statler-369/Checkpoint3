using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int Instrument_ID { get; set; }
        public string Instrument_Desc { get; set; }
        public string Rent_Type { get; set; }
        public int New_Price { get; set; }
        public int Used_Price { get; set; }
        public int Client_ID { get; set; }
    }
}