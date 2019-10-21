using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor.Models;

namespace Channel_A_Doctor.Pages.Appointments
{
    //Show all appointments.
    public class IndexModel : PageModel
    {
        //Database connection context
        private readonly Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext _context;

        public IndexModel(Channel_A_Doctor.Models.Channel_A_DoctorDatabaseContext context)
        {
            _context = context;
        }

        //Appointments List.
        public IList<Appointment> Appointment { get;set; }

        //Uses a lamda query to get all appointments wit related info.
        public void OnGet()
        {
            Appointment = _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient).ToList();
        }
    }
}
