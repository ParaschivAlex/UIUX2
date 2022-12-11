﻿using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PDP.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please enter a first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a second name!")]
        public string SecondName { get; set; }

        // Doctor's specialization
        [Required(ErrorMessage = "Please pick a specialization!")]
        public int SpecializationID { get; set; }

        // Whether the Doctor can be booked or not
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Please enter a price rate!")]
        [Range(typeof(double), "0.01", "100.00", ErrorMessage = "enter decimal value")]
        public double PriceRate { get; set; }

        [MinLength(10), MaxLength(12)]
        [Required(ErrorMessage = "Please enter a phone number!")]
        public string PhoneNumber { get; set; }

        [MinLength(7), MaxLength(25)]
        [Required(ErrorMessage = "Please enter an email!")]
        public string Email { get; set; }

        // A string which points to a doctor profile photo
        [Required(ErrorMessage = "Please enter a photo url!")]
        public string Photo { get; set; }

        // Calculated based on reviews
        public double Rating { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; }

        // Calculates consultation price
        public double CalcultateConsultationPrice(Specializations specialization)
        {
            return specialization.Price * this.PriceRate;
        }
    }
}
