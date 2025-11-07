// Interfaz para el Repositorio 
using ClinicaPetCare.Models;
using System.Collections.Generic;

namespace ClinicaPetCare.Data
{
    public interface IMascotaRepository
    {
        void AgregarMascota(Mascota mascota);
        IEnumerable<Mascota> ObtenerMascotas();
    }
}