using BibliotecaEscolarApp.Models;

// ================================
// OBJETOS DE PRUEBA
// ================================
Libro libro1       = new Libro(1, "Cien años de soledad", "Gabriel Garcia Marquez", 1967, "Novela", "978-0-06-088328-7");
Libro libro2       = new Libro(2, "El principito", "Antoine de Saint-Exupery", 1943, "Infantil", "978-0-15-601219-5");
Usuario usuario1   = new Usuario(1, "Juan Perez", "123456789", "juan@email.com");
Usuario usuario2   = new Usuario(2, "Maria Lopez", "987654321", "maria@email.com");
Prestamo prestamo1 = new Prestamo(1, 1, 1, DateTime.Now.AddDays(7));

// Punto de entrada
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
    Console.WriteLine("Aqui se registraria un nuevo libro.");
    Console.WriteLine("\nLibros actuales en el sistema:");
    Console.WriteLine(libro1.ResumenCorto());
    Console.WriteLine(libro2.ResumenCorto());
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
    Console.WriteLine(libro1.ResumenCorto());
    Console.WriteLine(libro2.ResumenCorto());
    Pausa();
}

void ListBooksAvailable()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS DISPONIBLES ===\n");
    bool hayDisponibles = false;
    if (libro1.Disponible) { Console.WriteLine(libro1.ResumenCorto()); hayDisponibles = true; }
    if (libro2.Disponible) { Console.WriteLine(libro2.ResumenCorto()); hayDisponibles = true; }
    if (!hayDisponibles) Console.WriteLine("No hay libros disponibles.");
    Pausa();
}

void ListBooksBorrowed()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS PRESTADOS ===\n");
    bool hayPrestados = false;
    if (!libro1.Disponible) { Console.WriteLine(libro1.ResumenCorto()); hayPrestados = true; }
    if (!libro2.Disponible) { Console.WriteLine(libro2.ResumenCorto()); hayPrestados = true; }
    if (!hayPrestados) Console.WriteLine("No hay libros prestados.");
    Pausa();
}

void ViewBookDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE LIBRO 1 ===\n");
    Console.WriteLine(libro1.DetalleCompleto());
    Console.WriteLine("\n=== DETALLE LIBRO 2 ===\n");
    Console.WriteLine(libro2.DetalleCompleto());
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
    Console.WriteLine($"Titulo actual del libro 1: {libro1.Titulo}");
    Console.WriteLine($"Titulo actual del libro 2: {libro2.Titulo}");
    Console.WriteLine("Aqui se cambiaria el titulo del libro seleccionado.");
    Pausa();
}

void EditBookAuthor()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR AUTOR ===");
    Console.WriteLine($"Autor actual del libro 1: {libro1.Autor}");
    Console.WriteLine($"Autor actual del libro 2: {libro2.Autor}");
    Console.WriteLine("Aqui se cambiaria el autor del libro seleccionado.");
    Pausa();
}

void EditBookYearCategory()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR AÑO Y CATEGORIA ===");
    Console.WriteLine($"Libro 1 → Año: {libro1.Anio} | Categoria: {libro1.Categoria}");
    Console.WriteLine($"Libro 2 → Año: {libro2.Anio} | Categoria: {libro2.Categoria}");
    Console.WriteLine("Aqui se cambiaria el año y la categoria del libro seleccionado.");
    Pausa();
}

void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR LIBRO ===");
    Console.WriteLine("Validar: no se puede eliminar si el libro esta prestado.\n");
    Console.WriteLine($"Libro 1: {libro1.Titulo} | Disponible: {libro1.Disponible}");
    Console.WriteLine($"Libro 2: {libro2.Titulo} | Disponible: {libro2.Disponible}");
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
    Console.WriteLine("Aqui se registraria un nuevo usuario.\n");
    Console.WriteLine("Usuarios actuales en el sistema:");
    Console.WriteLine(usuario1.ResumenCorto());
    Console.WriteLine(usuario2.ResumenCorto());
    Pausa();
}

void ListUsers()
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS USUARIOS ===\n");
    Console.WriteLine(usuario1.ResumenCorto());
    Console.WriteLine(usuario2.ResumenCorto());
    Pausa();
}

void ViewUserDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE USUARIO 1 ===\n");
    Console.WriteLine(usuario1.DetalleCompleto());
    Console.WriteLine("\n=== DETALLE USUARIO 2 ===\n");
    Console.WriteLine(usuario2.DetalleCompleto());
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
    Console.WriteLine($"Nombre actual usuario 1: {usuario1.Nombre}");
    Console.WriteLine($"Nombre actual usuario 2: {usuario2.Nombre}");
    Console.WriteLine("Aqui se cambiaria el nombre del usuario seleccionado.");
    Pausa();
}

void EditUserContact()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR CONTACTO ===");
    Console.WriteLine($"Contacto actual usuario 1: {usuario1.Contacto}");
    Console.WriteLine($"Contacto actual usuario 2: {usuario2.Contacto}");
    Console.WriteLine("Aqui se cambiaria el contacto del usuario seleccionado.");
    Pausa();
}

void ToggleUserActiveStatus()
{
    Console.Clear();
    Console.WriteLine("=== ACTIVAR / DESACTIVAR USUARIO ===\n");
    Console.WriteLine($"Usuario 1: {usuario1.Nombre} | Activo: {usuario1.Activo}");
    Console.WriteLine($"Usuario 2: {usuario2.Nombre} | Activo: {usuario2.Activo}");
    Console.WriteLine("\nAqui se cambiaria el estado del usuario seleccionado.");
    Pausa();
}

void DeleteUser()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR USUARIO ===");
    Console.WriteLine("Validar: no se puede eliminar si tiene prestamos activos.\n");
    Console.WriteLine($"Usuario 1: {usuario1.Nombre} | Activo: {usuario1.Activo}");
    Console.WriteLine($"Usuario 2: {usuario2.Nombre} | Activo: {usuario2.Activo}");
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
    Console.WriteLine("=== CREAR PRESTAMO ===");
    Console.WriteLine("Validaciones que se aplicarian:\n");
    Console.WriteLine("- El libro debe existir y estar disponible.");
    Console.WriteLine("- El usuario debe existir y estar activo.");
    Console.WriteLine("- El usuario no debe superar el limite de prestamos.\n");
    Console.WriteLine($"Libro 1 disponible: {libro1.Disponible}");
    Console.WriteLine($"Libro 2 disponible: {libro2.Disponible}");
    Console.WriteLine($"Usuario 1 activo: {usuario1.Activo}");
    Console.WriteLine($"Usuario 2 activo: {usuario2.Activo}");
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
    Console.WriteLine("--- LIBROS ---");
    Console.WriteLine($"{libro1.ResumenCorto()} | Disponible: {libro1.Disponible}");
    Console.WriteLine($"{libro2.ResumenCorto()} | Disponible: {libro2.Disponible}");
    Console.WriteLine("\n--- USUARIOS ---");
    Console.WriteLine($"{usuario1.ResumenCorto()} | Activo: {usuario1.Activo}");
    Console.WriteLine($"{usuario2.ResumenCorto()} | Activo: {usuario2.Activo}");
    Console.WriteLine("\n--- PRESTAMOS ---");
    Console.WriteLine(prestamo1.ResumenCorto());
    Console.WriteLine($"Esta vencido: {prestamo1.EstaVencido()}");
    Console.WriteLine($"Dias transcurridos: {prestamo1.DiasTranscurridos()}");
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
    Console.WriteLine("Aqui se guardarian todos los datos en un archivo.");
    Pausa();
}

void LoadData()
{
    Console.Clear();
    Console.WriteLine("=== CARGAR DATOS ===");
    Console.WriteLine("Aqui se cargarian los datos guardados previamente.");
    Pausa();
}

void ConfirmResetData()
{
    Console.Clear();
    Console.WriteLine("Seguro que desea reiniciar todos los datos? (S/N)");
    Console.Write("Respuesta: ");
    string respuesta = (Console.ReadLine() ?? "").ToUpper();
    if (respuesta == "S")
        Console.WriteLine("Todos los datos han sido reiniciados.");
    else
        Console.WriteLine("Operacion cancelada.");
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
