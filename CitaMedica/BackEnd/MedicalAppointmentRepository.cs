using CitaMedica.BackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitaMedica.BackEnd
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        private readonly List<MedicalAppointment> _DbContextMedicalAppointments;
        public MedicalAppointmentRepository(List<MedicalAppointment> medicalAppointmentsList )
        {
            _DbContextMedicalAppointments = medicalAppointmentsList;
        }


        public bool Delete(int id)
        {
            var query = _DbContextMedicalAppointments.Where(p => p.Id == id);
            if (query.FirstOrDefault() == null) throw new ArgumentNullException("No exists");
            var result = query.Update(p => { p.IsActive = false; });
            return result > 0;
        }

        public MedicalAppointment GetById(int id)
        {
            var medicalAppointment = _DbContextMedicalAppointments.Where(p => p.Id == id).FirstOrDefault();
            if (medicalAppointment == null) throw new ArgumentNullException("No exists");
            return medicalAppointment;
        }

        public MedicalAppointment Insert(MedicalAppointment medicalAppointment)
        {
            var medicalAppointmentResult = _DbContextMedicalAppointments.Where(p => p.Id == medicalAppointment.Id).FirstOrDefault();
            if (medicalAppointmentResult != null) throw new InvalidOperationException("medicalAppointment exists");
            _DbContextMedicalAppointments.Add(medicalAppointment);
            return medicalAppointment;
        }

        public MedicalAppointment Update(MedicalAppointment medicalAppointment, int id)
        {
            var query = _DbContextMedicalAppointments.Where(p => p.Id == id);
            if (query.FirstOrDefault() == null) throw new ArgumentNullException("No exists");

            query.Update(p => {
                p.Id = medicalAppointment.Id;
                p.IsActive = medicalAppointment.IsActive;
                p.Name = medicalAppointment.Name;
                p.Appointment = medicalAppointment.Appointment;
            });

            return query.FirstOrDefault();
        }
    }

    public static class UpdateExtensions
    {
        public delegate void Func<TArg0>(TArg0 element);
        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> update)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (update == null) throw new ArgumentNullException("update");
            if (typeof(TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");
            int count = 0;
            foreach (TSource element in source)
            {
                update(element);
                count++;
            }
            return count;
        }
    }


    public interface IMedicalAppointmentRepository
    {
        MedicalAppointment Insert (MedicalAppointment medicalAppointment);
        MedicalAppointment Update (MedicalAppointment medicalAppointment, int id);
        MedicalAppointment GetById(int id);
        bool Delete(int id);
    }
}
