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

namespace Channel_A_Doctor.Pages.Doctors
{
    //Updates a doctor.
    public class EditModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public EditModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Doctor information
        [BindProperty]
        public Doctor Doctor { get; set; }

        //Get the update doctor form uses a lamda query to get the information
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
           ViewData["MedicalCentreId"] = new SelectList(_context.Set<MedicalCentre>(), "Id", "Name");
            return Page();
        }

        //Updates the doctor information.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Doctor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.Id))
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

        //Checks doctor existance using a lamda query.
        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
