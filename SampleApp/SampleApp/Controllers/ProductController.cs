using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SampleApp.DAL;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL _productDAL = new Product_DAL();
        // GET: Product
        public ActionResult Index()
        {
            var productList = _productDAL.GetAllProducts();
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _productDAL.GetProduct(id);
            return View(product[0]);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            bool isInserted = false;
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    isInserted = _productDAL.InsertProduct(productModel);
                    if(isInserted)
                    {
                        TempData["SuccessMessage"] = "Product successfully added...!";

                    }else
                    {
                        TempData["ErrorMessage"] = "Unable to Save product";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message; 
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productDAL.GetProduct(id);
            return View(product[0]);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            try
            {
                bool isUpdated = false;
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    isUpdated = _productDAL.UpdateProduct(id,productModel);
                    if (isUpdated)
                    {
                        TempData["SuccessMessage"] = "Product successfully Updated...!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to Update product";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel productModel)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
