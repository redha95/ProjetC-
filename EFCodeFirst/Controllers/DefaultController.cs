using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class DefaultController : Controller
    {

        public ActionResult Index()
        {

           

            return View();

        }
        public ActionResult AjouterEtudiant()
        {
            return View();
        }

        public ActionResult AjouterStandard()
        {
            return View();
        }

        public ActionResult SupprimerEtudiant()
        {
            return View();
        }
        public ActionResult InsertStandard(FormCollection Fc)
        {


            using (SchoolContext context = new SchoolContext())
            {

                Standard stand = new Standard();
                stand.StandardName = Fc["Niveau"].ToString();

                context.Standards.Add(stand);

                int i = context.SaveChanges();
                if (i > 0)
                {
                    ViewBag.Msg = "Les données ont été insérée avec succès.";
                }
            }
            return View();
        }



        public ActionResult Modifier()
        {
            using (var context = new SchoolContext()) // MODIFIER 
            {
                Student stud = new Student() { StudentID = 1280, StudentName = "Admin", DateOfBirth = DateTime.Now };
                context.Students.Add(stud);
                context.Entry(stud).State = EntityState.Modified;
                context.SaveChanges();
            }


            return View();
        }

        public ActionResult Supprimer()
        {

            using (var context = new SchoolContext()) // SUPPRIMER TOUT LES ETUDIANTS
            {

                //var stud = context.Students.Find(5); // ici on veut supp l'id 4
                var students = context.Students.ToList();
                context.Students.RemoveRange(students);

                //context.Students.Remove(stud);
                context.SaveChanges();
            }
            return View();
        }



        public ActionResult Insert(FormCollection Fc, HttpPostedFileBase file)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Student stud = new Student();



                stud.StudentName = Fc["TxtName"].ToString();
                stud.DateOfBirth = Convert.ToDateTime(Fc["DateDeNaissance"]);
                stud.Height = Convert.ToDecimal(Fc["Taille"]);
                stud.Weight = float.Parse(Fc["Poids"]);

                var level = int.Parse(Fc["StandardID"]);
                stud.Standard = context.Standards.Find(level);

                
                
                  context.Students.Add(stud);

                int i = context.SaveChanges();
                if (i > 0)
                {
                    ViewBag.Msg = "Les données ont été insérée avec succès.";
                }
            }

            return View();
        }
        
        public ActionResult DeleteEtudiant(FormCollection Fc)
        {

            var id = int.Parse(Fc["EtudiantID"]);
            var result = RemoveById(id);
            if(result)
            {
                ViewBag.Msg = "Les données ont été supprimée avec succès.";
            }
            
            return View();
        }

        private bool RemoveById(int Id)
        {
            using (SchoolContext ctx = new SchoolContext())
            {
                var student = ctx.Students.Find(Id);
                if (student != null)
                {
                    ctx.Students.Remove(student);
                    ctx.SaveChanges();
                    return true;
                }
                    
            }
            return false;

        }


    }
}
