using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.MedicalCentres
{
    //Deletes a medical centre.
    public class DeleteModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DeleteModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Medical centre information.
        [BindProperty]
        public MedicalCentre MedicalCentre { get; set; }

        //Get the centre to delete using a lamda query.
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

        //Removes a centre uses a linq query to check presence.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalCentre = (from centre in _context.MedicalCentre
                             where centre.Id == id
                             select centre
                             ).FirstOrDefault();

            if (MedicalCentre != null)
            {
                _context.MedicalCentre.Remove(MedicalCentre);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
