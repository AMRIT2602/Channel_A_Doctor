using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Appointments
{
    //Deletes an appointment
    public class DeleteModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DeleteModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Appointment details.
        [BindProperty]
        public Appointment Appointment { get; set; }

        //Gets the appintment info. uses a lamda query to get the related infomation.
        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient).FirstOrDefault(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the appointment. uses linq query to check availability
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = (from appointment in _context.Appointment
                           where appointment.Id == id select appointment
                            ).FirstOrDefault() ;

            if (Appointment != null)
            {
                _context.Appointment.Remove(Appointment);
               _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
