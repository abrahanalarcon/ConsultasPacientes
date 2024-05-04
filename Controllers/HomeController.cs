using ConsultasPacientes12.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace ConsultasPacientes12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConsultasPacientesContext _Econtext;

        public HomeController(ConsultasPacientesContext Econtext)
        {
            _Econtext = Econtext;
        }

        public IActionResult Index()
        {
            
            List<Paciente> pacientes = _Econtext.Pacientes.ToList();

            
            List<Doctor> doctores = _Econtext.Doctors.ToList();

           
            ViewBag.Pacientes = pacientes;
            ViewBag.Doctores = doctores;

            return View(pacientes);
        }

       

        public IActionResult RegistroDoctor()
        {
            List<Doctor> listaDoctores = _Econtext.Doctors.ToList();


            ViewBag.Doctors = listaDoctores;

            return View(listaDoctores);
        }


        public IActionResult AgregarPaciente()
        {
            ViewBag.Doctors = _Econtext.Doctors.ToList();
            return View();

        }
        [HttpPost] 
        public IActionResult AgregarPaciente(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                
                _Econtext.Pacientes.Add(paciente);
                _Econtext.SaveChanges();

                return RedirectToAction("Index"); 
            }
            else
            {
                
                return View(paciente);
            }
        }

        public IActionResult AgregarDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _Econtext.Doctors.Add(doctor);
                _Econtext.SaveChanges();

                ViewBag.Doctors = _Econtext.Doctors.ToList();

                return RedirectToAction("RegistroDoctor"); 
            }
            else
            {
                return View(doctor);
            }
        }
        [HttpPost]
        public IActionResult ModificarPaciente(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Econtext.Pacientes.Update(paciente);
                    _Econtext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error al modificar el paciente: " + ex.Message);
                    ViewBag.Doctors = _Econtext.Doctors.ToList();
                    return View("ModificarPaciente", paciente);
                }
            }
            else
            {
                ViewBag.Doctors = _Econtext.Doctors.ToList();
                return View("ModificarPaciente", paciente);
            }
        }


        [HttpPost]
        public IActionResult EliminarPaciente(int id)
        {
            var paciente = _Econtext.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            try
            {
                _Econtext.Pacientes.Remove(paciente);
                _Econtext.SaveChanges();

                // Actualizar la lista de pacientes en ViewBag
                ViewBag.Pacientes = _Econtext.Pacientes.ToList();
            }
            catch (Exception ex)
            {
                // Manejar errores
                ModelState.AddModelError("", "Error al eliminar el paciente: " + ex.Message);
            }

            // Devolver la vista Index
            return View("Index", ViewBag.Pacientes);
        }






    }



}