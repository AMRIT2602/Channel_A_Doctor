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

namespace Channel_A_Doctor.Pages.MedicalCentres
{
    //Update the Centre details.
    public class EditModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public EditModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Centre information.
        [BindProperty]
        public MedicalCentre MedicalCentre { get; set; }

        //Gets the centre information form  .uses a lamda query to select the
        //Centre infromation.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalCentre =  _context.MedicalCentre.FirstOrDefault(m => m.Id == id);

            if (MedicalCentre == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Updates the centre information.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedicalCentre).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalCentreExists(MedicalCentre.Id))
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

        //Uses a lamda to select and check if the centre exists.
        private bool MedicalCentreExists(int id)
        {
            return _context.MedicalCentre.Any(e => e.Id == id);
        }
    }
}
