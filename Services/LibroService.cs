using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEscolarApp.Models;

namespace BibliotecaEscolarApp.Services
{
    class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine($"Libro '{libro.Titulo}' agregado correctamente.");
        }

        public void EliminarLibro(int id)
        {
            Libro libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
            {
                libros.Remove(libro);
                Console.WriteLine($"Libro '{libro.Titulo}' eliminado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un libro con ID {id}.");
            }
        }

        public List<Libro> ObtenerTodos() => libros;


      // ── BÚSQUEDAS ─────────────────────────────────────
        public Libro BuscarPorId(int id) =>
            libros.FirstOrDefault(l => l.Id == id);

        public Libro BuscarPorISBN(string isbn) =>
            libros.FirstOrDefault(l => l.ISBN == isbn);

        public List<Libro> BuscarPorTitulo(string titulo) =>
            libros.Where(l => l.Titulo.Contains(titulo,
                StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Libro> BuscarPorAutor(string autor) =>
            libros.Where(l => l.Autor.Contains(autor,
                StringComparison.OrdinalIgnoreCase)).ToList();

        // ── ORDENACIÓN ────────────────────────────────────
        public List<Libro> OrdenarPorTitulo() =>
            libros.OrderBy(l => l.Titulo).ToList();

        public List<Libro> OrdenarPorAnio() =>
            libros.OrderBy(l => l.Anio).ToList();  
    }
    



}