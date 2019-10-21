using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Doctors
{
    //Regsiter a new doctor.
    public class CreateModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public CreateModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Gets the create form 
        public IActionResult OnGet()
        {
        ViewData["MedicalCentreId"] = new SelectList(_context.Set<MedicalCentre>(), "Id", "Name");
            return Page();
        }

        //Doctor information.
        [BindProperty]
        public Doctor Doctor { get; set; }

        //Adds a doctor to the databse 
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Doctor.Add(Doctor);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}