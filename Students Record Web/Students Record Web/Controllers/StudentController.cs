using Students_Record_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students_Record_Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        StudentRecordManagementContext _context = new StudentRecordManagementContext();
        // GET: Student
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            var model = _context.Students.ToList();
            return View(model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Student student = _context.Students.Find(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student collection, HttpPostedFileBase ImageFile)
        {
            try
            {


                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                collection.ImagePath = "~/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                ImageFile.SaveAs(filename);

                _context.Students.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Student student = _context.Students.Find(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student collection,HttpPostedFileBase ImageFile)
        {
            try
            {
                Student student = _context.Students.Find(id);
                
                
                if(ImageFile!=null)
                {
                    string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    string extension = Path.GetExtension(ImageFile.FileName);
                    filename += DateTime.Now.ToString("yymmssfff") + extension;
                    collection.ImagePath = "~/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    ImageFile.SaveAs(filename);
                }
                else
                {
                    collection.ImagePath = student.ImagePath;   
                }

               

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Student student = _context.Students.Find(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Student student = _context.Students.Find(id);
                _context.Students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
