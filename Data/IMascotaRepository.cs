using ClinicaPetCare.Models;
using System.Collections.Generic;

namespace ClinicaPetCare.Data
{
    // Define los contratos (interfaz) para la gestión de datos de Mascota
    public interface IMascotaRepository
    {
        // Método para añadir una nueva mascota
        void AgregarMascota(Mascota mascota);

        // Método para obtener todas las mascotas registradas
        IEnumerable<Mascota> ObtenerMascotas();
    }
}