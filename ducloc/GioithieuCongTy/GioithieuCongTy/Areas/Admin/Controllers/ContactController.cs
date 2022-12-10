using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        private GioithieuContext db = new GioithieuContext();
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajax(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Contacts.ToList();

                
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Contacts.Where(i => i.Title.Contains(searchnow)).ToList();
                
                return Json(data, JsonRequestBehavior.AllowGet);

            }




        }





        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            
                Contact data = db.Contacts.Find(id);
                db.Contacts.Remove(data);
                db.SaveChanges();
                return Json(new { status = true });
            


        }


        /*public ActionResult ajaxDanhmuc()
        {
             return 
        }*/

        [HttpPost]
        public ActionResult Edit(string Title, string Address, double Phone, string Gmail, int id)
        {
            try
            {
                Contact Menu = db.Contacts.Find(id);
                Menu.Title = Title;
                Menu.Address = Address;
                Menu.Phone = Phone;
                Menu.Gmail = Gmail;
                
                Menu.Created_at = DateTime.Now;
                Menu.Update_at = DateTime.Now;


                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(string Title, string Address, string Slug, double Phone, string Gmail)
        {
            try
            {

                Contact myItem = new Contact();
                myItem.Title = Title;
                myItem.Address = Address;
                myItem.Phone = Phone;
                myItem.Gmail = Gmail;

                myItem.Created_at = DateTime.Now;
                myItem.Update_at = DateTime.Now;

                

                db.Contacts.Add(myItem);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }
    }
}