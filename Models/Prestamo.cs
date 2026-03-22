namespace BibliotecaEscolarApp.Models
{
    class Prestamo
    {
        // PROPIEDADES
        public int      Id              { get; set; }
        public int      LibroId         { get; set; }
        public int      UsuarioId       { get; set; }
        public DateTime FechaPrestamo   { get; set; }
        public DateTime FechaLimite     { get; set; }
        public DateTime? FechaDevolucion { get; set; } // null si no ha sido devuelto
        public EstadoPrestamo Estado    { get; set; }

       
        // CONSTRUCTOR VACÍO
       
        public Prestamo()
        {
            FechaPrestamo    = DateTime.Now;
            FechaLimite      = DateTime.Now.AddDays(7); // 7 días por defecto
            FechaDevolucion  = null;                    // aún no devuelto
            Estado           = EstadoPrestamo.Activo;   // siempre empieza activo
        }

     
        // CONSTRUCTOR COMPLETO
       
        public Prestamo(int id, int libroId, int usuarioId, DateTime fechaLimite)
        {
            Id               = id;
            LibroId          = libroId;
            UsuarioId        = usuarioId;
            FechaPrestamo    = DateTime.Now;
            FechaLimite      = fechaLimite;
            FechaDevolucion  = null;
            Estado           = EstadoPrestamo.Activo;
        }

       
        // MÉTODOS
       

        // Verifica si el préstamo ya venció
        public bool EstaVencido()
        {
            // si no ha sido devuelto y ya pasó la fecha límite → está vencido
            return FechaDevolucion == null && DateTime.Now > FechaLimite;
        }

        // Cuántos días han pasado desde que se hizo el préstamo
        public int DiasTranscurridos()
        {
            DateTime fechaFin = FechaDevolucion ?? DateTime.Now;
            return (int)(fechaFin - FechaPrestamo).TotalDays;
        }

        // Muestra la información básica del préstamo
        public string ResumenCorto()
        {
            return $"[{Id}] Libro:{LibroId} - Usuario:{UsuarioId} - Estado:{Estado}";
        }

        // Muestra toda la información del préstamo
        public string DetalleCompleto()
        {
            string devolucion = FechaDevolucion.HasValue
                ? FechaDevolucion.Value.ToString("yyyy-MM-dd")
                : "Pendiente";

            return $"ID: {Id}\n" +
                   $"Libro ID: {LibroId}\n" +
                   $"Usuario ID: {UsuarioId}\n" +
                   $"Fecha prestamo: {FechaPrestamo:yyyy-MM-dd}\n" +
                   $"Fecha limite: {FechaLimite:yyyy-MM-dd}\n" +
                   $"Fecha devolucion: {devolucion}\n" +
                   $"Estado: {Estado}\n" +
                   $"Dias transcurridos: {DiasTranscurridos()}\n" +
                   $"Esta vencido: {EstaVencido()}";
        }


        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}
