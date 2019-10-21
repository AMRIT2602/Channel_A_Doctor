using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;

namespace Channel_A_Doctor.Models
{
    //Connects the business layer to the database.
    public class Channel_A_DoctorDatabaseContext : DbContext
    {
        public Channel_A_DoctorDatabaseContext (DbContextOptions<Channel_A_DoctorDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Channel_A_Doctor.BusinessLayer.Appointment> Appointment { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.Doctor> Doctor { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.MedicalCentre> MedicalCentre { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.Patient> Patient { get; set; }
    }
}
