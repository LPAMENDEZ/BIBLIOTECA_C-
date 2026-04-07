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
    }
}