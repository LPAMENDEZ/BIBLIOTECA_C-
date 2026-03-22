
//   SISTEMA DE BIBLIOTECA - Menú Principal


ShowMainMenu();

static void ShowMainMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║     SISTEMA BIBLIOTECA       ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Libros                   ║");
        Console.WriteLine("║  2. Usuarios                 ║");
        Console.WriteLine("║  3. Préstamos                ║");
        Console.WriteLine("║  4. Búsquedas y reportes     ║");
        Console.WriteLine("║  5. Guardar / Cargar datos   ║");
        Console.WriteLine("║  6. Salir                    ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 6);

        switch (opcion)
        {
            case 1: ShowBooksMenu();         break;
            case 2: ShowUsersMenu();         break;
            case 3: ShowLoansMenu();         break;
            case 4: ShowSearchReportsMenu(); break;
            case 5: ShowPersistenceMenu();   break;
            case 6: ConfirmExitAndSave();    break;
        }
    }
}

// leer opción válida
static int LeerOpcion(string mensaje, int min, int max)
{
    int valor;
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";
        if (int.TryParse(entrada, out valor) && valor >= min && valor <= max)
            return valor;
        Console.WriteLine($"Opción inválida. Ingrese un número entre {min} y {max}.");
    }
}


// MENÚ LIBROS

static void ShowBooksMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║         LIBROS               ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Registrar libro          ║");
        Console.WriteLine("║  2. Listar libros            ║");
        Console.WriteLine("║  3. Ver detalle              ║");
        Console.WriteLine("║  4. Actualizar libro         ║");
        Console.WriteLine("║  5. Eliminar libro           ║");
        Console.WriteLine("║  6. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 6);

        switch (opcion)
        {
            case 1: RegisterBook();    break;
            case 2: ListBooksMenu();   break;
            case 3: ViewBookDetail();  break;
            case 4: UpdateBookMenu();  break;
            case 5: DeleteBook();      break;
            case 6: return;
        }
    }
}

static void RegisterBook()
{
    Console.Clear();
    Console.WriteLine("REGISTRAR LIBRO");
    Console.WriteLine("→ Aquí se registraría un nuevo libro (título, autor, año, categoría, ISBN).");
    Pausa();
}

static void ListBooksMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║       LISTAR LIBROS          ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Listar todos             ║");
        Console.WriteLine("║  2. Listar disponibles       ║");
        Console.WriteLine("║  3. Listar prestados         ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: ListBooksAll();       break;
            case 2: ListBooksAvailable(); break;
            case 3: ListBooksBorrowed();  break;
            case 4: return;
        }
    }
}

static void ListBooksAll()
{
    Console.Clear();
    Console.WriteLine("LISTAR TODOS LOS LIBROS");
    Console.WriteLine("→ Aquí se mostrarían todos los libros registrados en el sistema.");
    Pausa();
}

static void ListBooksAvailable()
{
    Console.Clear();
    Console.WriteLine("LISTAR LIBROS DISPONIBLES");
    Console.WriteLine("→ Aquí se mostrarían solo los libros disponibles para préstamo.");
    Pausa();
}

static void ListBooksBorrowed()
{
    Console.Clear();
    Console.WriteLine("LISTAR LIBROS PRESTADOS");
    Console.WriteLine("→ Aquí se mostrarían solo los libros actualmente prestados.");
    Pausa();
}

static void ViewBookDetail()
{
    Console.Clear();
    Console.WriteLine("VER DETALLE DE LIBRO");
    Console.WriteLine("→ Aquí se buscaría un libro por ID/ISBN y se mostraría su detalle completo.");
    Pausa();
}

static void UpdateBookMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║      ACTUALIZAR LIBRO        ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Editar título            ║");
        Console.WriteLine("║  2. Editar autor             ║");
        Console.WriteLine("║  3. Editar año / categoría   ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: EditBookTitle();        break;
            case 2: EditBookAuthor();       break;
            case 3: EditBookYearCategory(); break;
            case 4: return;
        }
    }
}

static void EditBookTitle()
{
    Console.Clear();
    Console.WriteLine("EDITAR TÍTULO");
    Console.WriteLine("→ Aquí se actualizaría el título del libro seleccionado.");
    Pausa();
}

static void EditBookAuthor()
{
    Console.Clear();
    Console.WriteLine("EDITAR AUTOR");
    Console.WriteLine("→ Aquí se actualizaría el autor del libro seleccionado.");
    Pausa();
}

static void EditBookYearCategory()
{
    Console.Clear();
    Console.WriteLine("EDITAR AÑO / CATEGORÍA");
    Console.WriteLine("→ Aquí se actualizarían el año y la categoría del libro seleccionado.");
    Pausa();
}

static void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("ELIMINAR LIBRO");
    Console.WriteLine("→ Validar: no permitir eliminar si el libro está prestado actualmente.");
    Pausa();
}