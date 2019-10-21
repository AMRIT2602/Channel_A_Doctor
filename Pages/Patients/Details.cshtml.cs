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
    //Gets the Patient details.
    public class DetailsModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DetailsModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Holds the patient infomation.
        public Patient Patient { get; set; }

        //Get patient details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient =_context.Patient.FirstOrDefault(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
