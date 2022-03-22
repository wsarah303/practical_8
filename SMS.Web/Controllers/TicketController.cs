using System;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;
using SMS.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.Web.Controllers
{
    public class TicketController : BaseController
    {
        private readonly IStudentService svc;
        public TicketController()
        {
            svc = new StudentServiceDb();
        }

        // GET /ticket/index
        public IActionResult Index()
        {
            var tickets = svc.GetOpenTickets();
            return View(tickets);
        }
       
        //  POST /ticket/close/{id}
        [HttpPost]
        public IActionResult Close(int id)
        {
            // TBC - close ticket via service then check that ticket was closed
            // if not display a warning/error alert otherwise a success alert

            return RedirectToAction(nameof(Index));
        }
       
        // GET /ticket/create
        public IActionResult Create()
        {
            // TBC - get list of students using service

            var tvm = new TicketViewModel {
                // TBC - populate select list property using list of students
            };

            // render blank form passing view model as a a parameter
            return View(tvm);
        }
       
        // POST /ticket/create
        [HttpPost]
        public IActionResult Create(TicketViewModel tvm)
        {
            // TBC - check if modelstate is valid and create ticket, display success alert and redirect to index
            

            // redisplay the form for editing
            return View(tvm);
        }
    }
}
