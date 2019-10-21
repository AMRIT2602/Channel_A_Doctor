using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Channel_A_Doctor.BusinessLayer
{
    //Stores Doctor information
    public class Doctor
    {
        //Doctor id
        public int Id { get; set; }

        //Doctor name
        public string Name { get; set; }
        //Doctor charge amount.
        public decimal Charge { get; set; }

        //Medical center Id 
        public int MedicalCentreId { get; set; }

        //Medicat centre relationship reference
        public MedicalCentre MedicalCentre { get; set; }
    }
}
