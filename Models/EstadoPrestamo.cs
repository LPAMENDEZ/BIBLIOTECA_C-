 
namespace BibliotecaEscolarApp.Models
{

    enum EstadoPrestamo
    {
        Activo,    // el préstamo está en curso
        Devuelto,  // el libro ya fue devuelto
        Vencido    // pasó la fecha límite y no fue devuelto
    }
}