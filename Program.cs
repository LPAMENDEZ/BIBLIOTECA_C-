using BibliotecaEscolarApp.Models;
using BibliotecaEscolarApp.Services;

// ================================
// COMPARACIÓN ARRAY vs LIST
// ================================
Console.WriteLine("========== ARRAY vs LIST ==========\n");

// CON ARRAY — tamaño fijo
string[] titulosArray = new string[3];
titulosArray[0] = "Cien años de soledad";
titulosArray[1] = "El Quijote";
titulosArray[2] = "La Odisea";

Console.WriteLine("Con ARRAY (tamaño fijo = 3):");
foreach (string t in titulosArray)
    Console.WriteLine($"  - {t}");

// CON LIST — tamaño dinámico
List<string> titulosList = new List<string>();
titulosList.Add("Cien años de soledad");
titulosList.Add("El Quijote");
titulosList.Add("La Odisea");
titulosList.Add("Harry Potter");   // se puede agregar sin límite
titulosList.Remove("El Quijote");  // se puede eliminar fácilmente

Console.WriteLine("\nCon LIST (tamaño dinámico):");
foreach (string t in titulosList)
    Console.WriteLine($"  - {t}");

Console.WriteLine("\nDiferencia clave:");
Console.WriteLine("  ARRAY → tamaño FIJO, no puede crecer ni reducirse.");
Console.WriteLine("  LIST  → tamaño DINÁMICO, crece y decrece libremente.");

Console.WriteLine("\nPresione Enter para continuar al sistema...");
Console.ReadLine();
Console.Clear();

// ================================
// OBJETOS DE PRUEBA
// ================================
Libro libro1       = new Libro(1, "Cien años de soledad", "Gabriel Garcia Marquez", 1967, "Novela", "978-0-06-088328-7");
Libro libro2       = new Libro(2, "El principito", "Antoine de Saint-Exupery", 1943, "Infantil", "978-0-15-601219-5");
Usuario usuario1   = new Usuario(1, "Juan Perez", "123456789", "juan@email.com");
Usuario usuario2   = new Usuario(2, "Maria Lopez", "987654321", "maria@email.com");
Prestamo prestamo1 = new Prestamo(1, 1, 1, DateTime.Now.AddDays(7));


// ══════════════════════════════════════════
// INSTANCIAR SERVICIOS
// ══════════════════════════════════════════
LibroService    libroService    = new LibroService();
UsuarioService  usuarioService  = new UsuarioService();
PrestamoService prestamoService = new PrestamoService();

List<Libro> libros = new List<Libro>();
List<Usuario> usuarios = new List<Usuario>();
List<Prestamo> prestamos = new List<Prestamo>();

// ── LIBROS ────────────────────────────────
Console.WriteLine("\n========== LIBROS ==========");
libroService.AgregarLibro(new Libro(1, "Cien años de soledad", "García Márquez", 1967, "Novela",   "ISBN-001"));
libroService.AgregarLibro(new Libro(2, "El Quijote",           "Cervantes",      1605, "Clásico",  "ISBN-002"));
libroService.AgregarLibro(new Libro(3, "La Odisea",            "Homero",        -800,  "Épica",    "ISBN-003"));
libroService.AgregarLibro(new Libro(4, "Harry Potter",         "Rowling",        1997, "Fantasía", "ISBN-004"));
libroService.AgregarLibro(new Libro(5, "El Principito",        "Saint-Exupéry", 1943,  "Infantil", "ISBN-005"));

libroService.BuscarPorId(2).Disponible = false;
libroService.BuscarPorId(4).Disponible = false;

Console.WriteLine("\nBúsqueda por autor 'Homero':");
libroService.BuscarPorAutor("Homero")
    .ForEach(l => Console.WriteLine($"  {l.ResumenCorto()}"));

Console.WriteLine("\nBúsqueda por título 'el':");
libroService.BuscarPorTitulo("el")
    .ForEach(l => Console.WriteLine($"  {l.ResumenCorto()}"));

Console.WriteLine("\nOrdenados por título:");
libroService.OrdenarPorTitulo()
    .ForEach(l => Console.WriteLine($"  {l.ResumenCorto()}"));

Console.WriteLine("\nOrdenados por año:");
libroService.OrdenarPorAnio()
    .ForEach(l => Console.WriteLine($"  {l.ResumenCorto()}"));

libroService.MostrarKPIs();
// Punto de entrada

// ── USUARIOS ──────────────────────────────
Console.WriteLine("\n========== USUARIOS ==========");
usuarioService.AgregarUsuario(new Usuario(1, "Ana Torres",   "CC-001", "ana@email.com"));
usuarioService.AgregarUsuario(new Usuario(2, "Carlos López", "CC-002", "carlos@email.com"));
usuarioService.AgregarUsuario(new Usuario(3, "María Gómez",  "CC-003", "maria@email.com"));
usuarioService.AgregarUsuario(new Usuario(4, "Juan Pérez",   "CC-004", "juan@email.com"));

usuarioService.BuscarPorId(2).Activo = false;

Console.WriteLine("\nBúsqueda por documento 'CC-003':");
Usuario u = usuarioService.BuscarPorDocumento("CC-003");
Console.WriteLine($"  {u?.DetalleCompleto()}");

Console.WriteLine("\nBúsqueda por nombre 'an':");
usuarioService.BuscarPorNombre("an")
    .ForEach(u => Console.WriteLine($"  {u.ResumenCorto()}"));

Console.WriteLine("\nOrdenados por nombre:");
usuarioService.OrdenarPorNombre()
    .ForEach(u => Console.WriteLine($"  {u.ResumenCorto()}"));

usuarioService.MostrarKPIs();

// ── PRÉSTAMOS ─────────────────────────────
Console.WriteLine("\n========== PRÉSTAMOS ==========");
prestamoService.AgregarPrestamo(new Prestamo(1, 2, 1, DateTime.Now.AddDays(5)));
prestamoService.AgregarPrestamo(new Prestamo(2, 4, 3, DateTime.Now.AddDays(-3)));
prestamoService.AgregarPrestamo(new Prestamo(3, 1, 2, DateTime.Now.AddDays(10)));

prestamoService.BuscarPorId(2).Estado          = EstadoPrestamo.Vencido;
prestamoService.BuscarPorId(3).Estado          = EstadoPrestamo.Devuelto;
prestamoService.BuscarPorId(3).FechaDevolucion = DateTime.Now.AddDays(-1);

Console.WriteLine("\nPréstamos activos:");
prestamoService.BuscarPorEstado(EstadoPrestamo.Activo)
    .ForEach(p => Console.WriteLine($"  {p.ResumenCorto()}"));

Console.WriteLine("\nPréstamos del usuario ID 1:");
prestamoService.BuscarPorUsuario(1)
    .ForEach(p => Console.WriteLine($"  {p.ResumenCorto()}"));

Console.WriteLine("\nOrdenados por fecha límite:");
prestamoService.OrdenarPorFechaLimite()
    .ForEach(p => Console.WriteLine(
        $"  {p.ResumenCorto()} - Límite: {p.FechaLimite:yyyy-MM-dd}"));

prestamoService.MostrarKPIs();
ShowMainMenu();

// ================================
// MENÚ PRINCIPAL
// ================================
void ShowMainMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA BIBLIOTECA ===");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Prestamos");
        Console.WriteLine("4. Busquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 6);

        if (opcion == 1) ShowBooksMenu();
        if (opcion == 2) ShowUsersMenu();
        if (opcion == 3) ShowLoansMenu();
        if (opcion == 4) ShowSearchReportsMenu();
        if (opcion == 5) ShowPersistenceMenu();
        if (opcion == 6) ConfirmExitAndSave();
    }
}



// ================================
// VALIDAR OPCIÓN
// ================================
int LeerOpcion(string mensaje, int min, int max)
{
    int valor;
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";
        if (int.TryParse(entrada, out valor) && valor >= min && valor <= max)
            return valor;
        Console.WriteLine($"Opcion invalida. Ingrese un numero entre {min} y {max}.");
    }
}

// ================================
// PAUSAR PANTALLA
// ================================
void Pausa()
{
    Console.WriteLine("\nPresione Enter para continuar...");
    Console.ReadLine();
}

// ================================
// MENÚ LIBROS
// ================================
void ShowBooksMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("=== LIBROS ===");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("6. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 6);

        if (opcion == 1) RegisterBook();
        if (opcion == 2) ListBooksMenu();
        if (opcion == 3) ViewBookDetail();
        if (opcion == 4) UpdateBookMenu();
        if (opcion == 5) DeleteBook();
    }
}

void RegisterBook()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR LIBRO ===");

    Console.Write("ID: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Titulo: ");
    string titulo = Console.ReadLine() ?? "";

    Console.Write("Autor: ");
    string autor = Console.ReadLine() ?? "";

    Console.Write("Año: ");
    int anio = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Categoria: ");
    string categoria = Console.ReadLine() ?? "";

    Console.Write("ISBN: ");
    string isbn = Console.ReadLine() ?? "";

    Libro nuevo = new Libro(id, titulo, autor, anio, categoria, isbn);

    libroService.AgregarLibro(nuevo);

    Console.WriteLine("\nLibro registrado correctamente ✅");
    Pausa();
}

void ListBooksMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR LIBROS ===");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) ListBooksAll();
        if (opcion == 2) ListBooksAvailable();
        if (opcion == 3) ListBooksBorrowed();
    }
}

void ListBooksAll()
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS LIBROS ===\n");

    var libros = libroService.ObtenerTodos();

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (var l in libros)
        {
            Console.WriteLine(l.ResumenCorto());
        }
    }

    Pausa();
}

void ListBooksAvailable()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS DISPONIBLES ===\n");

    var libros = libroService.ObtenerTodos();

    var disponibles = libros.Where(l => l.Disponible).ToList();

    if (disponibles.Count == 0)
    {
        Console.WriteLine("No hay libros disponibles.");
    }
    else
    {
        disponibles.ForEach(l => Console.WriteLine(l.ResumenCorto()));
    }

    Pausa();
}

void ListBooksBorrowed()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS PRESTADOS ===\n");

    var libros = libroService.ObtenerTodos();

    var prestados = libros.Where(l => !l.Disponible).ToList();

    if (prestados.Count == 0)
    {
        Console.WriteLine("No hay libros prestados.");
    }
    else
    {
        prestados.ForEach(l => Console.WriteLine(l.ResumenCorto()));
    }

    Pausa();
}

void ViewBookDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE DE LIBRO ===\n");

    var libros = libroService.ObtenerTodos();

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros.");
        Pausa();
        return;
    }

    for (int i = 0; i < libros.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {libros[i].Titulo}");
    }

    int opcion = LeerOpcion("Seleccione: ", 1, libros.Count);

    Console.WriteLine("\n" + libros[opcion - 1].DetalleCompleto());

    Pausa();
}
void UpdateBookMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR LIBRO ===");
        Console.WriteLine("1. Editar titulo");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año y categoria");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) EditBookTitle();
        if (opcion == 2) EditBookAuthor();
        if (opcion == 3) EditBookYearCategory();
    }
}

void EditBookTitle()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR TITULO ===");

    var libros = libroService.ObtenerTodos();

    for (int i = 0; i < libros.Count; i++)
        Console.WriteLine($"{i + 1}. {libros[i].Titulo}");

    int opcion = LeerOpcion("Seleccione: ", 1, libros.Count);

    Console.Write("Nuevo titulo: ");
    libros[opcion - 1].Titulo = Console.ReadLine() ?? "";

    Console.WriteLine("Actualizado correctamente ✅");
    Pausa();
}

void EditBookAuthor()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR AUTOR ===");

    var libros = libroService.ObtenerTodos();

    for (int i = 0; i < libros.Count; i++)
        Console.WriteLine($"{i + 1}. {libros[i].Titulo}");

    int opcion = LeerOpcion("Seleccione: ", 1, libros.Count);

    Console.Write("Nuevo autor: ");
    libros[opcion - 1].Autor = Console.ReadLine() ?? "";

    Console.WriteLine("Actualizado correctamente ✅");
    Pausa();
}
void EditBookYearCategory()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR AÑO Y CATEGORIA ===");

    var libros = libroService.ObtenerTodos();

    for (int i = 0; i < libros.Count; i++)
        Console.WriteLine($"{i + 1}. {libros[i].Titulo}");

    int opcion = LeerOpcion("Seleccione: ", 1, libros.Count);

    Console.Write("Nuevo año: ");
    libros[opcion - 1].Anio = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Nueva categoria: ");
    libros[opcion - 1].Categoria = Console.ReadLine() ?? "";

    Console.WriteLine("Actualizado correctamente ✅");
    Pausa();
}

void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR LIBRO ===");

    var libros = libroService.ObtenerTodos();

    for (int i = 0; i < libros.Count; i++)
        Console.WriteLine($"{i + 1}. {libros[i].Titulo}");

    int opcion = LeerOpcion("Seleccione: ", 1, libros.Count);

    var libro = libros[opcion - 1];

    if (!libro.Disponible)
    {
        Console.WriteLine("No se puede eliminar, el libro esta prestado ❌");
    }
    else
    {
        libros.Remove(libro);
        Console.WriteLine("Libro eliminado correctamente ✅");
    }

    Pausa();
}
// ================================
// MENÚ USUARIOS
// ================================
void ShowUsersMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS ===");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("6. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 6);

        if (opcion == 1) RegisterUser();
        if (opcion == 2) ListUsers();
        if (opcion == 3) ViewUserDetail();
        if (opcion == 4) UpdateUserMenu();
        if (opcion == 5) DeleteUser();
    }
}

void RegisterUser()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR USUARIO ===");

    Console.Write("ID: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("Documento: ");
    string documento = Console.ReadLine() ?? "";

    Console.Write("Correo: ");
    string correo = Console.ReadLine() ?? "";

    Usuario nuevo = new Usuario(id, nombre, documento, correo);

    usuarios.Add(nuevo); // 🔥 IMPORTANTE
    usuarioService.AgregarUsuario(nuevo);

    Console.WriteLine("\n Usuario registrado correctamente.");
    Pausa();
}

void ListUsers()
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS USUARIOS ===\n");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados.");
    }
    else
    {
        foreach (var u in usuarios)
        {
            Console.WriteLine(u.ResumenCorto());
        }
    }

    Pausa();
}

void ViewUserDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE USUARIO ===\n");

    foreach (var u in usuarios)
    {
        Console.WriteLine(u.DetalleCompleto());
        Console.WriteLine("----------------------");
    }

    Pausa();
}

void UpdateUserMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR USUARIO ===");
        Console.WriteLine("1. Editar nombre");
        Console.WriteLine("2. Editar contacto");
        Console.WriteLine("3. Activar o desactivar");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) EditUserName();
        if (opcion == 2) EditUserContact();
        if (opcion == 3) ToggleUserActiveStatus();
    }
}

void EditUserName()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR NOMBRE ===");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios.");
        Pausa();
        return;
    }

    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {usuarios[i].Nombre}");
    }

    int opcion = LeerOpcion("Seleccione usuario: ", 1, usuarios.Count);

    Console.Write("\nNuevo nombre: ");
    string nuevoNombre = Console.ReadLine() ?? "";

    usuarios[opcion - 1].Nombre = nuevoNombre;

    Console.WriteLine("\nNombre actualizado correctamente ✅");
    Pausa();
}

void EditUserContact()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR CONTACTO ===");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios.");
        Pausa();
        return;
    }

    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {usuarios[i].Nombre}");
    }

    int opcion = LeerOpcion("Seleccione usuario: ", 1, usuarios.Count);

    Console.Write("\nNuevo contacto: ");
    string nuevoContacto = Console.ReadLine() ?? "";

    usuarios[opcion - 1].Contacto = nuevoContacto;

    Console.WriteLine("\nContacto actualizado correctamente ✅");
    Pausa();
}
void ToggleUserActiveStatus()
{
    Console.Clear();
    Console.WriteLine("=== ACTIVAR / DESACTIVAR USUARIO ===\n");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios.");
        Pausa();
        return;
    }

    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {usuarios[i].Nombre} | Activo: {usuarios[i].Activo}");
    }

    int opcion = LeerOpcion("Seleccione usuario: ", 1, usuarios.Count);

    var usuario = usuarios[opcion - 1];
    usuario.Activo = !usuario.Activo;

    Console.WriteLine($"\nNuevo estado: {usuario.Activo}");
    Console.WriteLine("\nEstado actualizado correctamente ✅");

    Pausa();
}

void DeleteUser()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR USUARIO ===");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios.");
        Pausa();
        return;
    }

    foreach (var u in usuarios)
    {
        Console.WriteLine($"{u.Id} - {u.Nombre}");
    }

    Console.Write("\nIngrese el ID del usuario a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var usuario = usuarios.FirstOrDefault(u => u.Id == id);

    if (usuario != null)
    {
        usuarios.Remove(usuario);
        Console.WriteLine("Usuario eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Usuario no encontrado.");
    }

    Pausa();
}

// ================================
// MENÚ PRÉSTAMOS
// ================================
void ShowLoansMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("=== PRESTAMOS ===");
        Console.WriteLine("1. Crear prestamo");
        Console.WriteLine("2. Listar prestamos");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Registrar devolucion");
        Console.WriteLine("5. Eliminar prestamo");
        Console.WriteLine("6. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 6);

        if (opcion == 1) CreateLoan();
        if (opcion == 2) ListLoansMenu();
        if (opcion == 3) ViewLoanDetail();
        if (opcion == 4) RegisterReturn();
        if (opcion == 5) DeleteLoan();
    }
}

void CreateLoan()
{
    Console.Clear();
    Console.WriteLine("=== CREAR PRESTAMO ===\n");

    // Mostrar información actual real desde los services
    Console.WriteLine("Libros disponibles:");
    var librosDisponibles = libroService.BuscarPorTitulo(""); // trae todos
    foreach (var l in librosDisponibles)
    {
        Console.WriteLine($"{l.ResumenCorto()} | Disponible: {l.Disponible}");
    }

    Console.WriteLine("\nUsuarios registrados:");
    var usuariosRegistrados = usuarioService.BuscarPorNombre(""); // trae todos
    foreach (var u in usuariosRegistrados)
    {
        Console.WriteLine($"{u.ResumenCorto()} | Activo: {u.Activo}");
    }

    // Captura de datos
    Console.Write("\nID Prestamo: ");
    int idPrestamo = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("ID Usuario: ");
    int usuarioId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("ID Libro: ");
    int libroId = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Dias de prestamo: ");
    int dias = int.Parse(Console.ReadLine() ?? "7");

    // 🔍 VALIDACIONES REALES

    // Validar usuario
    var usuario = usuarioService.BuscarPorId(usuarioId);
    if (usuario == null)
    {
        Console.WriteLine("\nUsuario no existe.");
        Pausa();
        return;
    }

    if (!usuario.Activo)
    {
        Console.WriteLine("\nEl usuario no está activo.");
        Pausa();
        return;
    }

    // Validar libro
    var libro = libroService.BuscarPorId(libroId);
    if (libro == null)
    {
        Console.WriteLine("\nLibro no existe.");
        Pausa();
        return;
    }

    if (!libro.Disponible)
    {
        Console.WriteLine("\nEl libro no está disponible.");
        Pausa();
        return;
    }

    // Crear préstamo
    DateTime fechaLimite = DateTime.Now.AddDays(dias);
    Prestamo nuevo = new Prestamo(idPrestamo, libroId, usuarioId, fechaLimite);

    prestamoService.AgregarPrestamo(nuevo);

    // Actualizar estado del libro
    libro.Disponible = false;

    Console.WriteLine("\nPrestamo registrado correctamente ✅");
    Console.WriteLine(nuevo.DetalleCompleto());

    Pausa();
}
void ListLoansMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR PRESTAMOS ===");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) ListLoansAll();
        if (opcion == 2) ListLoansActive();
        if (opcion == 3) ListLoansClosed();
    }
}

void ListLoansAll()
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS PRESTAMOS ===\n");
    Console.WriteLine(prestamo1.ResumenCorto());
    Console.WriteLine($"Esta vencido: {prestamo1.EstaVencido()}");
    Console.WriteLine($"Dias transcurridos: {prestamo1.DiasTranscurridos()}");
        if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay prestamos registrados.");
    }
    else
    {
        foreach (var p in prestamos)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }
    Pausa();
}

void ListLoansActive()
{
    Console.Clear();
    Console.WriteLine("=== PRESTAMOS ACTIVOS ===\n");
    if (prestamo1.Estado == EstadoPrestamo.Activo)
        Console.WriteLine(prestamo1.ResumenCorto());
    else
        Console.WriteLine("No hay prestamos activos.");
    Pausa();
}

void ListLoansClosed()
{
    Console.Clear();
    Console.WriteLine("=== PRESTAMOS CERRADOS ===\n");
    if (prestamo1.Estado == EstadoPrestamo.Devuelto)
        Console.WriteLine(prestamo1.ResumenCorto());
    else
        Console.WriteLine("No hay prestamos cerrados.");
    Pausa();
}

void ViewLoanDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE DEL PRESTAMO ===\n");
    Console.WriteLine(prestamo1.DetalleCompleto());
    Pausa();
}

void RegisterReturn()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR DEVOLUCION ===\n");
    prestamo1.Estado          = EstadoPrestamo.Devuelto;
    prestamo1.FechaDevolucion = DateTime.Now;
    libro1.Disponible         = true;
    Console.WriteLine("El prestamo ha sido marcado como devuelto.");
    Console.WriteLine("El libro queda disponible nuevamente.\n");
    Console.WriteLine($"Estado del prestamo: {prestamo1.Estado}");
    Console.WriteLine($"Fecha devolucion: {prestamo1.FechaDevolucion:yyyy-MM-dd}");
    Console.WriteLine($"Libro 1 disponible: {libro1.Disponible}");
    Console.Write("Ingrese ID del prestamo: ");
int id = int.Parse(Console.ReadLine() ?? "0");

var prestamo = prestamos.FirstOrDefault(p => p.Id == id);

if (prestamo != null && prestamo.Estado == EstadoPrestamo.Activo)
{
    prestamo.Estado = EstadoPrestamo.Devuelto;
    prestamo.FechaDevolucion = DateTime.Now;

    var libro = libros.FirstOrDefault(l => l.Id == prestamo.LibroId);
    if (libro != null)
        libro.Disponible = true;

    Console.WriteLine("Prestamo devuelto correctamente.");
}
else
{
    Console.WriteLine(" Prestamo no encontrado o ya cerrado.");
}
    Pausa();
}

void DeleteLoan()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR PRESTAMO ===");
    Console.WriteLine("Solo se pueden eliminar prestamos cerrados.\n");
    Console.WriteLine($"Estado actual: {prestamo1.Estado}");
    if (prestamo1.Estado == EstadoPrestamo.Devuelto)
        Console.WriteLine("Este prestamo puede ser eliminado.");
    else
        Console.WriteLine("Este prestamo NO puede ser eliminado porque esta activo.");

        Console.Write("Ingrese ID del prestamo a eliminar: ");
int id = int.Parse(Console.ReadLine() ?? "0");

var prestamo = prestamos.FirstOrDefault(p => p.Id == id);

if (prestamo != null)
{
    if (prestamo.Estado == EstadoPrestamo.Devuelto)
    {
        prestamos.Remove(prestamo);
        Console.WriteLine("Prestamo eliminado.");
    }
    else
    {
        Console.WriteLine("No se puede eliminar un prestamo activo.");
    }
}
else
{
    Console.WriteLine("Prestamo no encontrado.");
}
    Pausa();
}

// ================================
// MENÚ BÚSQUEDAS Y REPORTES
// ================================
void ShowSearchReportsMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== BUSQUEDAS Y REPORTES ===");
        Console.WriteLine("1. Buscar libro");
        Console.WriteLine("2. Buscar usuario");
        Console.WriteLine("3. Reportes");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) SearchBook();
        if (opcion == 2) SearchUser();
        if (opcion == 3) ReportsMenu();
    }
}

void SearchBook()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR LIBRO ===\n");
    Console.WriteLine("Libros registrados en el sistema:");
    Console.WriteLine(libro1.ResumenCorto());
    Console.WriteLine(libro2.ResumenCorto());
    Pausa();
}

void SearchUser()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR USUARIO ===\n");
    Console.WriteLine("Usuarios registrados en el sistema:");
    Console.WriteLine(usuario1.ResumenCorto());
    Console.WriteLine(usuario2.ResumenCorto());
    Pausa();
}

void ReportsMenu()
{
    int opcion = 0;
    while (opcion != 5)
    {
        Console.Clear();
        Console.WriteLine("=== REPORTES ===");
        Console.WriteLine("1. Reporte por usuario");
        Console.WriteLine("2. Reporte por libro");
        Console.WriteLine("3. Prestamos vencidos");
        Console.WriteLine("4. Resumen general");
        Console.WriteLine("5. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 5);

        if (opcion == 1) ReportByUser();
        if (opcion == 2) ReportByBook();
        if (opcion == 3) ReportOverdue();
        if (opcion == 4) ReportSummary();
    }
}

void ReportByUser()
{
    Console.Clear();
    Console.WriteLine("=== REPORTE POR USUARIO ===\n");
    Console.WriteLine(usuario1.DetalleCompleto());
    Console.WriteLine($"\nPrestamo asociado: {prestamo1.ResumenCorto()}");
    Console.WriteLine($"Dias transcurridos: {prestamo1.DiasTranscurridos()}");
    Pausa();
}

void ReportByBook()
{
    Console.Clear();
    Console.WriteLine("=== REPORTE POR LIBRO ===\n");
    Console.WriteLine(libro1.DetalleCompleto());
    Console.WriteLine($"\nPrestamo asociado: {prestamo1.ResumenCorto()}");
    Console.WriteLine($"Esta vencido: {prestamo1.EstaVencido()}");
    Pausa();
}

void ReportOverdue()
{
    Console.Clear();
    Console.WriteLine("=== PRESTAMOS VENCIDOS ===\n");
    if (prestamo1.EstaVencido())
        Console.WriteLine(prestamo1.ResumenCorto());
    else
        Console.WriteLine("No hay prestamos vencidos.");
    Pausa();
}

void ReportSummary()
{
    Console.Clear();
    Console.WriteLine("=== RESUMEN GENERAL ===\n");

    // LIBROS
    Console.WriteLine("--- LIBROS ---");
    if (libros.Count == 0)
        Console.WriteLine("No hay libros.");
    else
    {
        foreach (var l in libros)
        {
            Console.WriteLine($"{l.ResumenCorto()} | Disponible: {l.Disponible}");
        }
    }

    // USUARIOS
    Console.WriteLine("\n--- USUARIOS ---");
    if (usuarios.Count == 0)
        Console.WriteLine("No hay usuarios.");
    else
    {
        foreach (var u in usuarios)
        {
            Console.WriteLine($"{u.ResumenCorto()} | Activo: {u.Activo}");
        }
    }

    // PRÉSTAMOS
    Console.WriteLine("\n--- PRESTAMOS ---");
    if (prestamos.Count == 0)
        Console.WriteLine("No hay prestamos.");
    else
    {
        foreach (var p in prestamos)
        {
            Console.WriteLine(p.ResumenCorto());
            Console.WriteLine($"  Vencido: {p.EstaVencido()}");
            Console.WriteLine($"  Dias: {p.DiasTranscurridos()}");
        }
    }

    Pausa();
}

// ================================
// MENÚ GUARDAR / CARGAR
// ================================
void ShowPersistenceMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("=== GUARDAR / CARGAR ===");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos");
        Console.WriteLine("4. Volver");

        opcion = LeerOpcion("Seleccione una opcion: ", 1, 4);

        if (opcion == 1) SaveData();
        if (opcion == 2) LoadData();
        if (opcion == 3) ConfirmResetData();
    }
}

void SaveData()
{
    Console.Clear();
    Console.WriteLine("=== GUARDAR DATOS ===");

    try
    {
        using (StreamWriter sw = new StreamWriter("datos.txt"))
        {
            sw.WriteLine("LIBROS");
            foreach (var l in libros)
                sw.WriteLine($"{l.Id}|{l.Titulo}|{l.Autor}|{l.Anio}|{l.Categoria}|{l.Disponible}");

            sw.WriteLine("USUARIOS");
            foreach (var u in usuarios)
                sw.WriteLine($"{u.Id}|{u.Nombre}|{u.Contacto}|{u.Activo}");

            sw.WriteLine("PRESTAMOS");
            foreach (var p in prestamos)
                sw.WriteLine($"{p.Id}|{p.UsuarioId}|{p.LibroId}|{p.Estado}|{p.FechaLimite}");
        }

        Console.WriteLine("Datos guardados correctamente ✅");
    }
    catch
    {
        Console.WriteLine("Error al guardar datos ❌");
    }

    Pausa();
}

void LoadData()
{
    Console.Clear();
    Console.WriteLine("=== CARGAR DATOS ===");

    if (!File.Exists("datos.txt"))
    {
        Console.WriteLine("No existe archivo de datos.");
        Pausa();
        return;
    }

    libros.Clear();
    usuarios.Clear();
    prestamos.Clear();

    string[] lineas = File.ReadAllLines("datos.txt");

    string seccion = "";

    foreach (var linea in lineas)
    {
        if (linea == "LIBROS" || linea == "USUARIOS" || linea == "PRESTAMOS")
        {
            seccion = linea;
            continue;
        }

        var partes = linea.Split('|');

        if (seccion == "LIBROS")
        {
            libros.Add(new Libro(
                int.Parse(partes[0]),
                partes[1],
                partes[2],
                int.Parse(partes[3]),
                partes[4],
                "N/A"
            )
            { Disponible = bool.Parse(partes[5]) });
        }
        else if (seccion == "USUARIOS")
        {
            usuarios.Add(new Usuario(
                int.Parse(partes[0]),
                partes[1],
                partes[2],
                ""
            )
            { Activo = bool.Parse(partes[3]) });
        }
        else if (seccion == "PRESTAMOS")
        {
            prestamos.Add(new Prestamo(
                int.Parse(partes[0]),
                int.Parse(partes[1]),
                int.Parse(partes[2]),
                DateTime.Parse(partes[4])
            )
            { Estado = Enum.Parse<EstadoPrestamo>(partes[3]) });
        }
    }

    Console.WriteLine("Datos cargados correctamente ✅");
    Pausa();
}

void ConfirmResetData()
{
    Console.Clear();
    Console.WriteLine("Seguro que desea reiniciar todos los datos? (S/N)");
    Console.Write("Respuesta: ");

    string respuesta = (Console.ReadLine() ?? "").ToUpper();

    if (respuesta == "S")
    {
        libros.Clear();
        usuarios.Clear();
        prestamos.Clear();

        Console.WriteLine("Todos los datos han sido eliminados ✅");
    }
    else
    {
        Console.WriteLine("Operacion cancelada.");
    }

    Pausa();
}

// ================================
// SALIR
// ================================
void ConfirmExitAndSave()
{
    Console.Clear();
    Console.WriteLine("Desea guardar antes de salir? (S/N)");
    Console.Write("Respuesta: ");

    string respuesta = (Console.ReadLine() ?? "").ToUpper();

    if (respuesta == "S")
    {
        SaveData();
        Console.WriteLine("Datos guardados. Hasta luego!");
    }
    else
    {
        Console.WriteLine("Hasta luego!");
    }

    Pausa();
    Environment.Exit(0);
}
