using ClinicaPetCare.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClinicaPetCare.Data
{
    // Implementación del repositorio usando una lista estática en memoria
    public class MascotaRepository : IMascotaRepository
    {
        // Lista para almacenar las mascotas 
        private static readonly List<Mascota> _mascotas = new List<Mascota>();
        private static int _nextId = 1;

        public void AgregarMascota(Mascota mascota)
        {
            // Asigna un ID antes de guardar
            mascota.Id = _nextId++;
            _mascotas.Add(mascota);
        }

        public IEnumerable<Mascota> ObtenerMascotas()
        {
            // Retorna una copia de la lista 
            return _mascotas.OrderByDescending(m => m.FechaIngreso).ToList();
        }
    }
}