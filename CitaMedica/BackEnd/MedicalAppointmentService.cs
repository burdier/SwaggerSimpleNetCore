using CitaMedica.BackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitaMedica.BackEnd
{
    public class MedicalAppointmentService : MedicalAppointmentRepository, IMedicalAppointmentService
    {
        public MedicalAppointmentService(List<MedicalAppointment> medicalAppointmentsList) : base(medicalAppointmentsList)
        {
        }

        public MedicalAppointment Add(MedicalAppointment medicalAppointment)
        {
           return Insert(medicalAppointment);
        }

        public bool Cancel(int id)
        {
            return Delete(id);
        }

        public MedicalAppointment Get(int id)
        {
            return GetById(id);
        }

        public MedicalAppointment Update(MedicalAppointment medicalAppointment, int id)
        {
            return base.Update(medicalAppointment,id);
        }
    }










    public interface IMedicalAppointmentService
    {
        MedicalAppointment Add(MedicalAppointment medicalAppointment);
        MedicalAppointment Update(MedicalAppointment medicalAppointment, int id);
        MedicalAppointment Get(int id);
        bool Cancel(int id);

    }
}
