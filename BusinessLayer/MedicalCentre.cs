using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Channel_A_Doctor.BusinessLayer
{
    //Medical centre information
    public class MedicalCentre
    {
        //Cetre ID 
        public int Id { get; set; }

        //Cetre name
        [Required]
        public string Name { get; set; }

        //Contact number
        [Required]
        public string Phone { get; set; }

    }
}
