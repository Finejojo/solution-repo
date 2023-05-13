using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TodoApp.Models;
using TodoApp.Services.Business;

namespace TodoApp.Controllers
{
    [HandleError]
    public class TodoController : Controller
    {
        ToDoService toDoService = new ToDoService();
        
        // GET: Todo
        public ActionResult Index(string search)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            int userId = (int)Session["Id"];
            var listTodo = search == null ? toDoService.UserTasks(userId): toDoService.SearchTasks(2, search);
            return View(listTodo);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            int userId = (int)Session["Id"];
            var listTodo = toDoService.UserTask(id, userId);
            if(listTodo.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(listTodo[0]);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(TodoModel todo)
        {
            bool isInserted = false;
            int userId = (int)Session["Id"];
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    isInserted = toDoService.SaveNewTask(userId,todo);
                    if (isInserted)
                    {
                        TempData["SuccessMessage"] = "Task successfully added...!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to Add Task";
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

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            int userId = (int)Session["Id"];
            var listTodo = toDoService.UserTask(id, userId);
            if(listTodo.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(listTodo[0]);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TodoModel todo)
        {
            bool isUpdated = false;
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    isUpdated = toDoService.UpdateTask(id, todo);
                    if (isUpdated)
                    {
                        TempData["SuccessMessage"] = "Task successfully added...!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to Add Task";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            int userId = (int)Session["Id"];
            var listTodo = toDoService.UserTask(id, userId);
            if(listTodo.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(listTodo[0]);
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TodoModel todo)
        {
            var isDeleted = false;
            
            try
            {
                // TODO: Add delete logic here
                
                isDeleted = toDoService.DeleteTask(id);
                if (isDeleted)
                {
                    TempData["SuccessMessage"] = "Task successfully added...!";

                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to Add Task";
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult DeleteAll()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAll(TodoModel todoModel)
        {
            bool isDeleted = false;
            int userId = (int)Session["Id"];
            try
            {
                isDeleted=toDoService.DeleteAllTask(userId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
