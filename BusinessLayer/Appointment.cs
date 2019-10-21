using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Channel_A_Doctor.BusinessLayer
{
    //Store appointment infomation
    public class Appointment
    {
        //Appointment Id
        public int Id { get; set; }

        //Doctor Id
        public int DoctorId { get; set; }

        //Patient Id
        public int PatientId { get; set; }

        //Patient relationship 
        public Patient Patient { get; set; }

        //Doctor relationship

        public Doctor Doctor { get; set; }

        //Appoint ment data and time
        public DateTime AppointmentDate { get; set; }

    }
}
