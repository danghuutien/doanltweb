using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class PostController : Controller
    {

        private GioithieuContext db = new GioithieuContext();
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajax(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Posts.ToList();

                foreach (var item in data)
                {
                    var category = db.Categorys.Find(int.Parse(item.CatId));
                    if (category != null)
                    {
                        item.CatId = category.Name;
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Posts.Where(i => i.Title.Contains(searchnow)).ToList();
                foreach (var item in data)
                {
                    var category = db.Categorys.Find(int.Parse(item.CatId));
                    if (category != null)
                    {
                        item.CatId = category.Name;
                    }
                }
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
                Post data = db.Posts.Find(id);
                db.Posts.Remove(data);
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
        public ActionResult Edit(string Content, string Title, string Slug, string CatId, string Thumbnail, string Excerpt, int id)
        {
            try
            {
                Post Menu = db.Posts.Find(id);
                Menu.Title = Title;
                Menu.Content = Content;
                Menu.CatId = CatId;
                Menu.Slug = Slug;
                Menu.Thumbnail = Thumbnail;
                Menu.Excerpt = Excerpt;
                Menu.Created_at = DateTime.Now;
                
                Menu.Updated_at = DateTime.Now;
                

                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Thumbnail, string Content, string Title, string Slug, string CatId, string Excerpt)
        {
            try
            {
                
                Post myItem = new Post();
                myItem.Title = Title;
                myItem.Content = Content;
                myItem.CatId = CatId;
                myItem.Slug = Slug;
                /*myItem.Thumbnail = Thumbnail;*/
                myItem.Excerpt = Excerpt;
                myItem.Created_at = DateTime.Now;

                myItem.Updated_at = DateTime.Now;

                if (Thumbnail != null )
                {
                   

                    string _FileName = "";

                    int index = Thumbnail.FileName.IndexOf('.');

                    _FileName = "Posts" + Slug + "." + Thumbnail.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Admin/public/images"), _FileName);
                    Thumbnail.SaveAs(_path);
                    myItem.Thumbnail = _FileName;
                }

                db.Posts.Add(myItem);
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