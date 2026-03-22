namespace BibliotecaEscolarApp.Models
{
    class Usuario
    {
    
        // PROPIEDADES
      
        public int    Id       { get; set; }
        public string Nombre   { get; set; }
        public string Documento { get; set; }
        public string Contacto { get; set; }
        public bool   Activo   { get; set; }

        // ========================
        // CONSTRUCTOR VACÍO
        // ========================
        public Usuario()
        {
            Nombre    = "";
            Documento = "";
            Contacto  = "";
            Activo    = true;
        }

        
        // CONSTRUCTOR COMPLETO
       
        public Usuario(int id, string nombre, string documento, string contacto)
        {
            Id        = id;
            Nombre    = nombre;
            Documento = documento;
            Contacto  = contacto;
            Activo    = true; 
        }

     
        // MÉTODOS
      

       
        public string ResumenCorto()
        {
            return $"[{Id}] {Nombre} - Doc: {Documento}";
        }

      
        public string DetalleCompleto()
        {
            string estado = Activo ? "Activo" : "Inactivo";
            return $"ID: {Id}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Documento: {Documento}\n" +
                   $"Contacto: {Contacto}\n" +
                   $"Estado: {estado}";
        }

        
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}
