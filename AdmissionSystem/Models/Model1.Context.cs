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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdmissionEntities4 : DbContext
    {
        public AdmissionEntities4()
            : base("name=AdmissionEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CourseInfo> CourseInfoes { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<FeeStatu> FeeStatus { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<HighSchool> HighSchools { get; set; }
        public virtual DbSet<LogIn> LogIns { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Pin> Pins { get; set; }
        public virtual DbSet<Program1> Program1 { get; set; }
        public virtual DbSet<Program2> Program2 { get; set; }
        public virtual DbSet<Program3> Program3 { get; set; }
        public virtual DbSet<Program4> Program4 { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Serial> Serials { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
    }
}
