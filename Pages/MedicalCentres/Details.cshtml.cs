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
    //Show details of  the Centre 
    public class DetailsModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public DetailsModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Centre information.
        public MedicalCentre MedicalCentre { get; set; }

        //Gets the cenre information using a lamda query.
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
    }
}
