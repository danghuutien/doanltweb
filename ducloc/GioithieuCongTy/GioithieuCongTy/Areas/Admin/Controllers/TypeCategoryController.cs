﻿using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class TypeCategoryController : Controller
    {
        private GioithieuContext db = new GioithieuContext();
        // GET: Admin/TypeCategory
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ajax(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Typecategorys.ToList();

               
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Typecategorys.Where(i => i.Name.Contains(searchnow)).ToList();
                
                return Json(data, JsonRequestBehavior.AllowGet);

            }




        }



        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dk = id.ToString();
            var cat = db.Categorys.Where(i => i.Typecategory_id == dk).ToList();
            var len = cat.Count;
            if (len <= 0)
            {
                Typecategory data = db.Typecategorys.Find(id);
                db.Typecategorys.Remove(data);
                db.SaveChanges();
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }


        /*public ActionResult ajaxDanhmuc()
        {
             return 
        }*/

        [HttpPost]
        public ActionResult Edit(string name, string slug, int id)
        {
            try
            {
                Typecategory Menu = db.Typecategorys.Find(id);
                Menu.Name = name;
                
                Menu.Slug = slug;
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
        public ActionResult Create(string name, string slug)
        {
            try
            {
                Typecategory myItem = new Typecategory();
                myItem.Name = name;
                
                myItem.Slug = slug;
                myItem.Created_at = DateTime.Now;
                db.Typecategorys.Add(myItem);
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