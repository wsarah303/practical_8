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
            var ticket = svc.CloseTicket(id);
            // if not display a warning/error alert otherwise a success alert
            if (ticket != null)
            {
                Alert(" No ticket found", AlertType.warning);
            }
            Alert($"ticket { id} closed", AlertType.info);
            return RedirectToAction(nameof(Index));
        }


        // GET /ticket/create
        public IActionResult Create()
        {
            // TBC - get list of students using service
            var students = svc.GetStudents();

            var tvm = new TicketViewModel
            {
                // TBC - populate select list property using list of students
                Students = new SelectList(students, "id", "name")

            };
            // render blank form passing view model as a a parameter
            return View(tvm);
        }
       
        // POST /ticket/create
        [HttpPost]
        public IActionResult Create(TicketViewModel tvm)
        {
            // TBC - check if modelstate is valid and create ticket, display success alert and redirect to index
            if (ModelState.IsValid)
        {
             svc.CreateTicket(tvm.StudentId, tvm.Issue);
                Alert($"Ticket is Created", AlertType.info);
                return RedirectToAction(nameof(Index));

        }

            // redisplay the form for editing
            return View(tvm);
        }
    }
}
