using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

//Adds a medical centre.
namespace Channel_A_Doctor.Pages.MedicalCentres
{
    public class CreateModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public CreateModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Gets the form to add centre.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Centre details.
        [BindProperty]
        public MedicalCentre MedicalCentre { get; set; }

        //Adds a centre to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalCentre.Add(MedicalCentre);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}