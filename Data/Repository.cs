using ClinicaPetCare.Models;

namespace ClinicaPetCare.Data
{
    public class MascotaRepository : IMascotaRepository
    {
        // Lista en memoria para simular el almacenamiento temporal 
        private static readonly List<Mascota> _mascotas = new List<Mascota>();
        private static int _nextId = 1;

        public void AgregarMascota(Mascota mascota)
        {
            // Asigna un ID único y añade la mascota a la lista
            mascota.Id = _nextId++;
            _mascotas.Add(mascota);
        }

        public IEnumerable<Mascota> ObtenerMascotas()
        {
            // Retorna la lista de mascotas, ordenada por ID o nombre si se desea
            return _mascotas.OrderByDescending(m => m.Id);
        }
    }
}