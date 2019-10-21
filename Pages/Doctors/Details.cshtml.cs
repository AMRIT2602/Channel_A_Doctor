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
    //Gets the selected doctor infomation.
    public class DetailsModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DetailsModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Doctor details.
        public Doctor Doctor { get; set; }

        //Gets doctor details including reltionships using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = _context.Doctor
                .Include(d => d.MedicalCentre).FirstOrDefault(m => m.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
