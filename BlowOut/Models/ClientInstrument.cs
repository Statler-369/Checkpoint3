using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class ClientInstrument
    {
        [Key]
        public int orderNum { get; set; }
        public Client client { get; set; }
        public Instrument instrument { get; set; }

    }
}