//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdmissionSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseInfo
    {
        public int CourseId { get; set; }
        public string Hall { get; set; }
        public string FeeStatus { get; set; }
        public string Program1 { get; set; }
        public string Program2 { get; set; }
        public string Program3 { get; set; }
        public string Program4 { get; set; }
    
        public virtual FeeStatu FeeStatu { get; set; }
        public virtual Hall Hall1 { get; set; }
        public virtual Program1 Program11 { get; set; }
        public virtual Program2 Program21 { get; set; }
        public virtual Program3 Program31 { get; set; }
        public virtual Program4 Program41 { get; set; }
    }
}
