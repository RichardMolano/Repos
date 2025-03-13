using Microsoft.EntityFrameworkCore;
using TripulacionGoingMerry.Models;
using WebApplication_GoingMerry.Models; // Asegúrate de importar el espacio de nombres correcto

namespace WebApplication_GoingMerry.DAL
{
    public static class TripInitializer
    {
        public static void Seed(TripContext context)
        {
            // Asegurar que la base de datos está creada (esto evita errores si aún no existe)
            context.Database.EnsureCreated();

            // Verificar si la tabla ya tiene datos para evitar duplicados
            if (!context.Tripulants.Any())
            {
                var tripulants = new List<Tripulant>
                {
                    new Tripulant { Name = "Luffy", EnrollmentDate = DateTime.Parse("2023-01-01") },
                };

                context.Tripulants.AddRange(tripulants);
                context.SaveChanges();
            }

            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment { TripulantID = 1, Tripulant = context.Tripulants.First(t => t.Name == "Luffy") },
                };

                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}