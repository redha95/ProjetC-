using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class DefaultController : Controller
    {
        private SchoolContext context = new SchoolContext();


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

        public ActionResult ListEtudiant()
        {
         
            return View(context.Students.ToList());
        }

    



        public ActionResult InsertStandard(FormCollection Fc)
        {
            
                Standard stand = new Standard();
                stand.StandardName = Fc["Niveau"].ToString();

                context.Standards.Add(stand);

                int i = context.SaveChanges();
                if (i > 0)
                {
                    ViewBag.Msg = "Les données ont été insérée avec succès.";
                }
            
            return View();
        }



        public ActionResult Modifier()
        {
           
                Student stud = new Student() { StudentID = 1280, StudentName = "Admin", DateOfBirth = DateTime.Now };
                context.Students.Add(stud);
                context.Entry(stud).State = EntityState.Modified;
                context.SaveChanges();
           


            return View();
        }

        public ActionResult Supprimer()
        {
            
                var students = context.Students.ToList();
                context.Students.RemoveRange(students);
            
                context.SaveChanges();
            
            return View();
        }



        public ActionResult Insert(FormCollection Fc, HttpPostedFileBase file)
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
             var student = context.Students.Find(Id);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    return true;
                }
                    
           
            return false;

        }

        public ActionResult Details(int? id)
        {

            if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = context.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
         
            return View();
        }

    }
}
