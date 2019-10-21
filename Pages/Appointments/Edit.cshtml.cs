using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Appointments
{
    //Updates an appointment.
    public class EditModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public EditModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Appintment details.
        [BindProperty]
        public Appointment Appointment { get; set; }

        //Appointment dettails form uses a lamda query to get the details.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment =  _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient).FirstOrDefault(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }
           ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name", Appointment.DoctorId);
           ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name", Appointment.PatientId);
            return Page();
        }

        //Updates the appointment.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Check appointment using lamda query.
        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
