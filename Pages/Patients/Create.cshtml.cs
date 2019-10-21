using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Patients
{
    //Add a new Patient.
    public class CreateModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public CreateModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Gets the patient form
        public IActionResult OnGet()
        {
            return Page();
        }

        //Patent info.
        [BindProperty]
        public Patient Patient { get; set; }

        //Create new patient in database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patient.Add(Patient);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}