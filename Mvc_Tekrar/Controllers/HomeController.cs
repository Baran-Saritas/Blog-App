using Microsoft.AspNetCore.Mvc;
using Mvc_Tekrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Tekrar.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(int? id, int pageIndex = 0)
        {
            using (var context = new Context())
            {
                var BlogList = from d1 in context.Blog
                               join d2 in context.Category on d1.CategoryId equals d2.id
                               select new BlogCategoryView
                               {
                                   id = d1.id,
                                   CategoryId = d2.id,
                                   CategoryName = d2.CategoryName,
                                   BlogTitle = d1.BlogTitle,
                                   NumberOfClicks = d1.NumberOfClicks

                               };
                var skipRows = (pageIndex) * 10;
                ViewBag.PageIndex = pageIndex;
                var data = BlogList.OrderByDescending(x => x.id).Skip(skipRows).Take(9).ToList();
                ViewBag.TotalData = data.Count();
                if (id != null)
                {
                    data = BlogList.Where(p => p.CategoryId == id).ToList();
                }

                ViewBag.Categories = context.Category.ToList(); // Kategoriler
                return View(data);

            }
        }
        public IActionResult Details(int id)
        {

            using (var context = new Context())
            {

                var blogDetails = context.Blog.FirstOrDefault(p => p.id == id); // tiklanilan kartin bilgileri
                blogDetails.NumberOfClicks += 1;
                ViewBag.LatestArticles = context.Blog.OrderByDescending(x => x.NumberOfClicks).Take(10).ToList();   // Bütün veriler izlenmeye gore
                context.SaveChanges();
                return View(blogDetails);
            }


        }

        public IActionResult Create()
        {
            using (var context = new Context())
            {
                ViewBag.Categories = context.Category.ToList();
                return View(new Blog());
            }

        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            using (var context = new Context())
            {

                ViewBag.Categories = context.Category.ToList();
                if (ModelState.IsValid)
                {
                    #region Add Blog

                    context.Add(blog);
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }
                #endregion


                return View(blog);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var context = new Context())
            {
                ViewBag.id = id;
                ViewBag.Categories = context.Category.ToList();
                var BlogData = context.Blog.FirstOrDefault(p => p.id == id);
                return View(BlogData);
            }
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            using (var context = new Context())
            {
                var gBlog = context.Blog.FirstOrDefault(p => p.id == blog.id);

                gBlog.BlogTitle = blog.BlogTitle;
                gBlog.CategoryId = blog.CategoryId;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {

            using (var context = new Context())
            {
                var blog = context.Blog.FirstOrDefault(p => p.id == id);

                context.Blog.Attach(blog);
                context.Blog.Remove(blog);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}
