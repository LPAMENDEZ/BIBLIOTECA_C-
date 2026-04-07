using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEscolarApp.Models;

namespace BibliotecaEscolarApp.Services
{
    class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            Console.WriteLine($"Usuario '{usuario.Nombre}' agregado correctamente.");
        }

        public void EliminarUsuario(int id)
        {
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                Console.WriteLine($"Usuario '{usuario.Nombre}' eliminado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un usuario con ID {id}.");
            }
        }

        public List<Usuario> ObtenerTodos() => usuarios;
        // ── BÚSQUEDAS ─────────────────────────────────────
        public Usuario BuscarPorId(int id) =>
            usuarios.FirstOrDefault(u => u.Id == id);

        public Usuario BuscarPorDocumento(string documento) =>
            usuarios.FirstOrDefault(u => u.Documento == documento);

        public List<Usuario> BuscarPorNombre(string nombre) =>
            usuarios.Where(u => u.Nombre.Contains(nombre,
                StringComparison.OrdinalIgnoreCase)).ToList();

        // ── ORDENACIÓN ────────────────────────────────────
        public List<Usuario> OrdenarPorNombre() =>
            usuarios.OrderBy(u => u.Nombre).ToList();
    }
}