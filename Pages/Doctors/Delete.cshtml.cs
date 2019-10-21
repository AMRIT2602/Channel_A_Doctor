using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Doctors
{
    //Deletes a doctor 
    public class DeleteModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DeleteModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Doctor information
        [BindProperty]
        public Doctor Doctor { get; set; }

        //Get the doctor information. uses lamda query to selelec the doctor from database.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor =  _context.Doctor
                .Include(d => d.MedicalCentre).FirstOrDefault(m => m.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the doctor. uses a linq query to check the presence
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = (from doctor in _context.Doctor

                      where doctor.Id == id
                      select doctor).FirstOrDefault();

            if (Doctor != null)
            {
                _context.Doctor.Remove(Doctor);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
