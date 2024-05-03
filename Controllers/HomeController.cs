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

                return RedirectToAction("RegistroDoctor"); // Redirige a la vista "RegistroDoctor"
            }
            else
            {
                return View(doctor);
            }
        }
        [HttpPost]
        public IActionResult ModificarPaciente(int id)
        {
            var paciente = _Econtext.Pacientes.Find(id);

            if (paciente == null)
            {
                return NotFound();
            }

            // Obtener la lista de doctores y pasarla a la vista
            ViewBag.Doctors = _Econtext.Doctors.ToList();

            return View("ModificarPaciente", paciente);
        }

        [HttpPost]
        public IActionResult EliminarPaciente(int id)
        {
            var paciente = _Econtext.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            else
            {
                _Econtext.Pacientes.Remove(paciente);
                _Econtext.SaveChanges();

                return RedirectToAction(nameof(Index));


            }


        }



    }



}