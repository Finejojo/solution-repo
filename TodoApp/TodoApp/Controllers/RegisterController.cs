using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;
using TodoApp.Services.Business;

namespace TodoApp.Controllers
{
    [HandleError]
    public class RegisterController : Controller
    {
        RegistrationService _registrationService = new RegistrationService();
        // GET: Register
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(RegisterModel registerModel)
        {
            bool isRegistered = false;
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    isRegistered = _registrationService.Register(registerModel);
                    if (isRegistered)
                    {
                        TempData["SuccessMessage"] = "Registered successfully...!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to Register";
                    }
                }

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
