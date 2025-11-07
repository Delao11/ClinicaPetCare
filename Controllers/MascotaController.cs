using ClinicaPetCare.Data;
using ClinicaPetCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaPetCare.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaRepository _mascotaRepository;

        // Inyección de Dependencias
        public MascotaController(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }


        public IActionResult Index()
        {
            // 1. Obtener la lista de mascotas para mostrar en la tabla
            var mascotas = _mascotaRepository.ObtenerMascotas();

            // 2. Crear un nuevo modelo vacío para el formulario
            var nuevaMascota = new Mascota();

            // Pasar la lista y el modelo vacío a la vista
            ViewData["Mascotas"] = mascotas;
            return View(nuevaMascota); // Pasa el modelo Mascota al formulario
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Registrar(Mascota mascota)
        {
          
            if (ModelState.IsValid)
            {
                // Agregar la mascota al repositorio 
                _mascotaRepository.AgregarMascota(mascota);

                // Mensaje de éxito para la vista
                TempData["MensajeExito"] = $"¡{mascota.Nombre} ha sido registrado exitosamente!";

                // Redirige a la acción Index para recargar la lista y mostrar el mensaje
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores de validación, volvemos a cargar la vista Index
            // Debemos recuperar la lista de mascotas nuevamente para que la tabla no esté vacía
            ViewData["Mascotas"] = _mascotaRepository.ObtenerMascotas();
            TempData["MensajeError"] = "¡Error de validación! Revisa los campos marcados.";

            // Retorna la vista con el modelo que contiene los errores
            return View("Index", mascota);
        }
    }
}