using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitaMedica.BackEnd;
using CitaMedica.BackEnd.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitaMedica.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitasMedicasController : ControllerBase
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        public CitasMedicasController(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        // GET: api/CitasMedicas
        [HttpGet("{id}")]
        public ActionResult<MedicalAppointment> Get(int id)
        {
            try
            {
                return _medicalAppointmentService.Get(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Agregar una cita medica 
        /// </summary>
        /// <param name="medicalAppointment"></param>
        /// <returns>Retorna los datos de la cita</returns>
        [HttpPost]
        public ActionResult<MedicalAppointment> Post(MedicalAppointment medicalAppointment)
        {
            try
            {
              return _medicalAppointmentService.Add(medicalAppointment);
            }
            catch (Exception ex)
            { 
              return BadRequest(ex.Message);
            }
        }


        // GET: api/CitasMedicas
        [HttpPut("{id}")]
        public ActionResult<MedicalAppointment> Put(MedicalAppointment medicalAppointment, int id)
        {
            try
            {
                return _medicalAppointmentService.Update(medicalAppointment, id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // GET: api/CitasMedicas
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return _medicalAppointmentService.Cancel(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
