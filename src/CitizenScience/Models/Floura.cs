using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenScience.Models
{
    [Table("Flouras")]
    public class Floura
    {
        public int FlouraId { get; set; }
        public byte[] FlouraPhoto { get; set; }
        public string FlouraName { get; set; }
        public string FlouraDescripton { get; set; }
        public int FlouraLength { get; set; }
        public int FlouraHeight { get; set; }
        public string FlouraColor { get; set; }
        public int FlouraLocatoin { get; set; }
    }
}
