﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CitizenScience.Models
{
    [Table("Faunas")]
    
    public class Fauna
    {
        [Key]
        public int FaunaId { get; set;}
        public byte[] FaunaPhoto { get; set; }
        public string FaunaName { get; set; }
        public string FaunaDescripton { get; set; }
        public int FaunaLength { get; set; }
        public int FaunaHeight { get; set; }
        public string FaunaColor { get; set; }
        public string FaunaLatitude { get; set; }
        public string FaunaLongitude { get; set; }
        public string FaunaDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Fauna() { }
        public Fauna(byte[] faunaPhoto, string faunaName, string faunaDescripion, int faunaLength, int faunaHeight, string faunaColor, string faunaLatitude, string faunaLongitude, DateTime faunaDate) {
            FaunaPhoto = faunaPhoto;
            FaunaName = faunaName;
            FaunaDescripton = faunaDescripion;
            FaunaLength = faunaLength;
            FaunaHeight = faunaHeight;
            FaunaColor = faunaColor;
            FaunaLatitude = faunaLatitude;
            FaunaLongitude = faunaLongitude;
            FaunaDate = FaunaDate;
           
        }
    }
    
}
