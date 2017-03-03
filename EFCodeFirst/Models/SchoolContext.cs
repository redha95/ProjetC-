using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EFCodeFirst.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("School")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //Map entity to table
            modelBuilder.Entity<Student>().ToTable("Etudiant");
            modelBuilder.Entity<Standard>().ToTable("Niveau");   // Renomme la table STANDARD 


            

            modelBuilder.Entity<Student>().HasKey<int>(p => p.StudentID);  // Dit que la clé primaire est StudentID

            modelBuilder.Entity<Student>().Property(t => t.StudentName).IsRequired().HasMaxLength(30)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,new IndexAnnotation(new IndexAttribute("IX_FirstNameLastName", 1) { IsUnique = true }));


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }


    }
}
