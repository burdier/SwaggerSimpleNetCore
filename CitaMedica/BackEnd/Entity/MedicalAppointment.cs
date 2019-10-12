using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitaMedica.BackEnd.Entity
{
    public class MedicalAppointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Appointment { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
