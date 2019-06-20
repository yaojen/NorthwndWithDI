﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Northwnd.Models;
using Northwnd.Models.Interface;
using Northwnd.Models.Repository;
using Northwnd.Service;
using Northwnd.Service.Interface;

namespace Northwnd.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductsController()
        {
            productService = new ProductService();
            categoryService = new CategoryService();
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetByID(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = categoryService.GetAll().Select(x => new { CategoryID = x.CategoryID, CategoryName = x.CategoryName });
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Create(product);
                return RedirectToAction("Index");
            }

            // ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CategoryID = categoryService.GetAll().Select(x => new { CategoryID = x.CategoryID, CategoryName = x.CategoryName });
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CategoryID = categoryService.GetAll().Select(x => new { CategoryID = x.CategoryID, CategoryName = x.CategoryName });
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CategoryID = categoryService.GetAll().Select(x => new { CategoryID = x.CategoryID, CategoryName = x.CategoryName });
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetByID(id.Value);
               
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
