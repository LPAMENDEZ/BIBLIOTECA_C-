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
    }
}