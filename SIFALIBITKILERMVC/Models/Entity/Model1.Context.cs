//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIFALIBITKILERMVC.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MedicinalPlantsEntities : DbContext
    {
        public MedicinalPlantsEntities()
            : base("name=MedicinalPlantsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Plants> Plants { get; set; }
        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<VisitorMessages> VisitorMessages { get; set; }
    }
}
