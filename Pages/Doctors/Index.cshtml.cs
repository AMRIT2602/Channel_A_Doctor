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
    //Get all doctors
    public class IndexModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public IndexModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }


        //Doctors List

        public IList<Doctor> Doctor { get;set; }

        //Get all doctors using a lamda query.
        public void  OnGet()
        {
            Doctor =  _context.Doctor
                .Include(d => d.MedicalCentre).ToList();
        }
    }
}
