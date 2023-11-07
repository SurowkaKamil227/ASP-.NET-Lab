using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;

namespace Laboratorium_3.Controllers
{
    public class ContactController : Controller
    {
        static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        static int _id = 1;
        public IActionResult Index()
        {
            return View(_contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
           if (ModelState.IsValid)
           {
               model.Id = _id++;
                _contacts[model.Id] = model;
               return RedirectToAction("Index");
           }
           return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_contacts.ContainsKey(id))
            {
                var contact = _contacts[id];
                return View(contact);
            }

            return NotFound();
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contacts.Remove(model.Id);
            return RedirectToAction("Index");
        }
    }
}
 