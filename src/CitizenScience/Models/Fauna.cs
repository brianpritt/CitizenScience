﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenScience.Models
{
    [Table("Faunas")]
    
    public class Fauna
    {

        public int FaunaId { get; set;}
        public byte[] FaunaPhoto { get; set; }
        public string FaunaName { get; set; }
        public string FaunaDescripton { get; set; }
        public int FaunaLength { get; set; }
        public int FaunaHeight { get; set; }
        public string FaunaColor { get; set; }
        public string FaunaLocation { get; set; }
        public virtual ApplicationUser Submitter { get; set; }

        public Fauna(byte[] faunaPhoto, string faunaName, string faunaDescripion, int faunaLength, int faunaHeight, string faunaColor, string faunaLocation ) {
            FaunaPhoto = faunaPhoto;
            FaunaName = faunaName;
            FaunaDescripton = faunaDescripion;
            FaunaLength = faunaLength;
            FaunaHeight = faunaHeight;
            FaunaColor = faunaColor;
            FaunaLocation = faunaLocation;
        }
    }
    
}
