using GioithieuCongTy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    
    public class MenuController : Controller
    {
        private GioithieuContext db = new GioithieuContext();

        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxDanhmuc(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Categorys.ToList();
                foreach (var item in data)
                {
                    var Typecategory = db.Typecategorys.Find(int.Parse(item.Typecategory_id));
                    if (Typecategory != null)
                    {
                        item.Typecategory_id = Typecategory.Name;
                    }
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Categorys.Where(i => i.Name.Contains(searchnow) ).ToList();
                foreach (var item in data)
                {
                    var Typecategory = db.Typecategorys.Find(int.Parse(item.Typecategory_id));
                    if (Typecategory != null)
                    {
                        item.Typecategory_id = Typecategory.Name;
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);
                
            }


            

        }

        public ActionResult GetDanhmuc(string txtSearch, int? page)
        {
            var data = db.Categorys.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetTypeCategory(string txtSearch, int? page)
        {
            var data = db.Typecategorys.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult DeleteDanhmuc(int id)
        {
            Category Menu = db.Categorys.Find(id);
            db.Categorys.Remove(Menu);
            db.SaveChanges();
            return Json(new { status = true });
        }


        /*public ActionResult ajaxDanhmuc()
        {
             return 
        }*/

        [HttpPost]
        public ActionResult EditDanhmuc(string name, string slug, string Typecategory_id, string ParentId, int id)
        {
            try
            {
                Category Menu = db.Categorys.Find(id);
                Menu.Name = name;
                Menu.Typecategory_id = Typecategory_id;
                Menu.ParentId = ParentId;
                Menu.Slug = slug;
                Menu.Created_at = DateTime.Now;
                Menu.Created_by = DateTime.Now;
                Menu.Updated_at = DateTime.Now;
                Menu.Updated_by = DateTime.Now;
                
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch(InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

        [HttpPost]
        public ActionResult CreateDanhmuc(string name, string slug, string Typecategory_id, string ParentId)
        {
            try
            {
                Category myItem = new Category();
                myItem.Name = name;
                myItem.Typecategory_id = Typecategory_id;
                myItem.ParentId = ParentId;
                myItem.Slug = slug;
                myItem.Created_at = DateTime.Now;
                db.Categorys.Add(myItem);
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