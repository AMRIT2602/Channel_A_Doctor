using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Patients
{

    //Delets a patient.
    public class DeleteModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DeleteModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Patient information.
        [BindProperty]
        public Patient Patient { get; set; }

        //Get Patient details.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient =  _context.Patient.FirstOrDefault(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the patient information uses linq query to check presence.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = (from patient in _context.Patient

                       where patient.Id == id select patient).FirstOrDefault();

            if (Patient != null)
            {
                _context.Patient.Remove(Patient);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
