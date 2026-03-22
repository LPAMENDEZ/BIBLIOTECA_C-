namespace BibliotecaEscolarApp.Models
{
    class Libro
    {
     
        // PROPIEDADES
    
        public int Id          { get; set; }
        public string Titulo   { get; set; }
        public string Autor    { get; set; }
        public int Anio        { get; set; }
        public string Categoria { get; set; }
        public string ISBN     { get; set; }
        public bool Disponible { get; set; }

        // CONSTRUCTORES
        public Libro()
        {
            Titulo    = "";
            Autor     = "";
            Categoria = "";
            ISBN      = "";
            Disponible = true; 
        }

      
        public Libro(int id, string titulo, string autor, int anio, string categoria, string isbn)
        {
            Id        = id;
            Titulo    = titulo;
            Autor     = autor;
            Anio      = anio;
            Categoria = categoria;
            ISBN      = isbn;
            Disponible = true; 
        }

    
        // MÉTODOS

        
        public string ResumenCorto()
        {
            return $"[{Id}] {Titulo} - {Autor} ({Anio})";
        }

                public string DetalleCompleto()
        {
            string estado = Disponible ? "Disponible" : "Prestado";
            return $"ID: {Id}\n" +
                   $"Titulo: {Titulo}\n" +
                   $"Autor: {Autor}\n" +
                   $"Año: {Anio}\n" +
                   $"Categoria: {Categoria}\n" +
                   $"ISBN: {ISBN}\n" +
                   $"Estado: {estado}";
        }

        
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}
