using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEscolarApp.Models;

namespace BibliotecaEscolarApp.Services
{
    class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
            Console.WriteLine($"Préstamo ID '{prestamo.Id}' registrado correctamente.");
        }

        public void EliminarPrestamo(int id)
        {
            Prestamo prestamo = prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                prestamos.Remove(prestamo);
                Console.WriteLine($"Préstamo ID '{id}' eliminado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un préstamo con ID {id}.");
            }
        }

        public List<Prestamo> ObtenerTodos() => prestamos;

        // ── BÚSQUEDAS ─────────────────────────────────────
        public Prestamo BuscarPorId(int id) =>
            prestamos.FirstOrDefault(p => p.Id == id);

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado) =>
            prestamos.Where(p => p.Estado == estado).ToList();

        public List<Prestamo> BuscarPorUsuario(int usuarioId) =>
            prestamos.Where(p => p.UsuarioId == usuarioId).ToList();

        public List<Prestamo> BuscarPorLibro(int libroId) =>
            prestamos.Where(p => p.LibroId == libroId).ToList();

        // ── ORDENACIÓN ────────────────────────────────────
        public List<Prestamo> OrdenarPorFechaLimite() =>
            prestamos.OrderBy(p => p.FechaLimite).ToList();

        public List<Prestamo> OrdenarPorFechaPrestamo() =>
            prestamos.OrderBy(p => p.FechaPrestamo).ToList();

            // ── KPIs ──────────────────────────────────────────
        public int TotalPrestamos() => prestamos.Count;

        public int PrestamosActivos() =>
            prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);

        public int PrestamosVencidos() =>
            prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido);

        public int PrestamosDevueltos() =>
            prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);

        public double PromedioDiasPrestamo()
        {
            if (!prestamos.Any()) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }

        public void MostrarKPIs()
        {
            Console.WriteLine("\n========== KPIs PRÉSTAMOS ==========");
            Console.WriteLine($"Total préstamos:    {TotalPrestamos()}");
            Console.WriteLine($"Activos:            {PrestamosActivos()}");
            Console.WriteLine($"Vencidos:           {PrestamosVencidos()}");
            Console.WriteLine($"Devueltos:          {PrestamosDevueltos()}");
            Console.WriteLine($"Promedio días:      {PromedioDiasPrestamo():F1} días");
            Console.WriteLine("=====================================");
        }
    }
}