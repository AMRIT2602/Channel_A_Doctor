using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Appointments
{
    //Submit appointment
    public class CreateModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public CreateModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Get the appointment form
        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name");
        ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name");
            return Page();
        }

        //Appointment information
        [BindProperty]
        public Appointment Appointment { get; set; }

        //Adds an appointment to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}