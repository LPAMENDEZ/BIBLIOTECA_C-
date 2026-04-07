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
    }
}