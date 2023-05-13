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
    public class LoginController : Controller
    {
        LoginService loginService = new LoginService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(LoginModel login)
        {
            
            try
            {
                // TODO: Add insert logic here
                
                if (ModelState.IsValid)
                {
                    var user = loginService.Login(login);   
                    if (user.Count > 0)
                    {
                        Session["Id"] = user[0].Id;
                        Session["Name"] = user[0].Name;
                        TempData["SuccessMessage"] = "Successfully Logged In..!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to Login";
                    }
                }
                
                return RedirectToAction("Index","Todo");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
