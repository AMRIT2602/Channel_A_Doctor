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
    //Gets all centres 
    public class IndexModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public IndexModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Keeps the list of centres 
        public IList<MedicalCentre> MedicalCentre { get;set; }

        //Uses a linq query to get all centres.
        public void  OnGet()
        {
            MedicalCentre =  (from centre in _context.MedicalCentre
                              select centre).ToList();
        }
    }
}
