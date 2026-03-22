
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

// MENÚ USUARIOS

static void ShowUsersMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║         USUARIOS             ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Registrar usuario        ║");
        Console.WriteLine("║  2. Listar usuarios          ║");
        Console.WriteLine("║  3. Ver detalle              ║");
        Console.WriteLine("║  4. Actualizar usuario       ║");
        Console.WriteLine("║  5. Eliminar usuario         ║");
        Console.WriteLine("║  6. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 6);

        switch (opcion)
        {
            case 1: RegisterUser();   break;
            case 2: ListUsers();      break;
            case 3: ViewUserDetail(); break;
            case 4: UpdateUserMenu(); break;
            case 5: DeleteUser();     break;
            case 6: return;
        }
    }
}

static void RegisterUser()
{
    Console.Clear();
    Console.WriteLine("REGISTRAR USUARIO");
    Console.WriteLine("→ Aquí se registraría un nuevo usuario (nombre, documento, contacto).");
    Pausa();
}

static void ListUsers()
{
    Console.Clear();
    Console.WriteLine("LISTAR USUARIOS");
    Console.WriteLine("→ Aquí se mostrarían todos los usuarios registrados en el sistema.");
    Pausa();
}

static void ViewUserDetail()
{
    Console.Clear();
    Console.WriteLine("VER DETALLE DE USUARIO");
    Console.WriteLine("→ Aquí se buscaría un usuario por ID/documento y se mostraría su detalle.");
    Pausa();
}

static void UpdateUserMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║     ACTUALIZAR USUARIO       ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Editar nombre            ║");
        Console.WriteLine("║  2. Editar contacto          ║");
        Console.WriteLine("║  3. Activar / desactivar     ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: EditUserName();           break;
            case 2: EditUserContact();        break;
            case 3: ToggleUserActiveStatus(); break;
            case 4: return;
        }
    }
}

static void EditUserName()
{
    Console.Clear();
    Console.WriteLine("EDITAR NOMBRE");
    Console.WriteLine("→ Aquí se actualizaría el nombre del usuario seleccionado.");
    Pausa();
}

static void EditUserContact()
{
    Console.Clear();
    Console.WriteLine("EDITAR CONTACTO");
    Console.WriteLine("→ Aquí se actualizaría el contacto del usuario seleccionado.");
    Pausa();
}

static void ToggleUserActiveStatus()
{
    Console.Clear();
    Console.WriteLine("ACTIVAR / DESACTIVAR USUARIO");
    Console.WriteLine("→ Aquí se cambiaría el estado activo/inactivo del usuario seleccionado.");
    Pausa();
}

static void DeleteUser()
{
    Console.Clear();
    Console.WriteLine("ELIMINAR USUARIO");
    Console.WriteLine("→ Validar: no permitir eliminar si el usuario tiene préstamos activos.");
    Pausa();
}


// MENÚ PRÉSTAMOS

static void ShowLoansMenu()
{
    int opcion = 0;
    while (opcion != 6)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║        PRÉSTAMOS             ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Crear préstamo           ║");
        Console.WriteLine("║  2. Listar préstamos         ║");
        Console.WriteLine("║  3. Ver detalle              ║");
        Console.WriteLine("║  4. Registrar devolución     ║");
        Console.WriteLine("║  5. Eliminar préstamo        ║");
        Console.WriteLine("║  6. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 6);

        switch (opcion)
        {
            case 1: CreateLoan();      break;
            case 2: ListLoansMenu();   break;
            case 3: ViewLoanDetail();  break;
            case 4: RegisterReturn();  break;
            case 5: DeleteLoan();      break;
            case 6: return;
        }
    }
}

static void CreateLoan()
{
    Console.Clear();
    Console.WriteLine("CREAR PRÉSTAMO");
    Console.WriteLine("→ Validaciones que se aplicarían:");
    Console.WriteLine("   • El libro debe existir y estar disponible.");
    Console.WriteLine("   • El usuario debe existir y estar activo.");
    Console.WriteLine("   • El usuario no debe superar el límite de préstamos.");
    Console.WriteLine("   • Se registraría fecha de préstamo y fecha de devolución estimada.");
    Pausa();
}

static void ListLoansMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║      LISTAR PRÉSTAMOS        ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Todos                    ║");
        Console.WriteLine("║  2. Activos                  ║");
        Console.WriteLine("║  3. Cerrados                 ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: ListLoansAll();    break;
            case 2: ListLoansActive(); break;
            case 3: ListLoansClosed(); break;
            case 4: return;
        }
    }
}

static void ListLoansAll()
{
    Console.Clear();
    Console.WriteLine(" TODOS LOS PRÉSTAMOS");
    Console.WriteLine("→ Aquí se mostrarían todos los préstamos registrados.");
    Pausa();
}

static void ListLoansActive()
{
    Console.Clear();
    Console.WriteLine("PRÉSTAMOS ACTIVOS");
    Console.WriteLine("→ Aquí se mostrarían los préstamos que aún no han sido devueltos.");
    Pausa();
}

static void ListLoansClosed()
{
    Console.Clear();
    Console.WriteLine("PRÉSTAMOS CERRADOS");
    Console.WriteLine("→ Aquí se mostrarían los préstamos ya devueltos.");
    Pausa();
}

static void ViewLoanDetail()
{
    Console.Clear();
    Console.WriteLine("VER DETALLE DE PRÉSTAMO");
    Console.WriteLine("→ Aquí se buscaría un préstamo por ID y se mostraría su detalle completo.");
    Pausa();
}

static void RegisterReturn()
{
    Console.Clear();
    Console.WriteLine("REGISTRAR DEVOLUCIÓN");
    Console.WriteLine("→ Aquí se marcaría el préstamo como devuelto y el libro quedaría disponible.");
    Pausa();
}

static void DeleteLoan()
{
    Console.Clear();
    Console.WriteLine("ELIMINAR PRÉSTAMO");
    Console.WriteLine("→ Reglas sugeridas:");
    Console.WriteLine("   • Solo se permitiría eliminar préstamos cerrados.");
    Console.WriteLine("   • No se puede eliminar un préstamo activo.");
    Pausa();
}


// MENÚ BÚSQUEDAS Y REPORTES

static void ShowSearchReportsMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║   BÚSQUEDAS Y REPORTES       ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Buscar libro             ║");
        Console.WriteLine("║  2. Buscar usuario           ║");
        Console.WriteLine("║  3. Reportes                 ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: SearchBook();    break;
            case 2: SearchUser();    break;
            case 3: ReportsMenu();   break;
            case 4: return;
        }
    }
}

static void SearchBook()
{
    Console.Clear();
    Console.WriteLine("BUSCAR LIBRO");
    Console.WriteLine("→ Aquí se buscaría un libro por título, autor, ID o categoría.");
    Pausa();
}

static void SearchUser()
{
    Console.Clear();
    Console.WriteLine("BUSCAR USUARIO");
    Console.WriteLine("→ Aquí se buscaría un usuario por nombre o ID/documento.");
    Pausa();
}

static void ReportsMenu()
{
    int opcion = 0;
    while (opcion != 5)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║          REPORTES            ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Reporte por usuario      ║");
        Console.WriteLine("║  2. Reporte por libro        ║");
        Console.WriteLine("║  3. Préstamos vencidos       ║");
        Console.WriteLine("║  4. Resumen general          ║");
        Console.WriteLine("║  5. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 5);

        switch (opcion)
        {
            case 1: ReportByUser();  break;
            case 2: ReportByBook();  break;
            case 3: ReportOverdue(); break;
            case 4: ReportSummary(); break;
            case 5: return;
        }
    }
}

static void ReportByUser()
{
    Console.Clear();
    Console.WriteLine("REPORTE POR USUARIO");
    Console.WriteLine("→ Aquí se mostrarían todos los préstamos asociados a un usuario.");
    Pausa();
}

static void ReportByBook()
{
    Console.Clear();
    Console.WriteLine("REPORTE POR LIBRO");
    Console.WriteLine("→ Aquí se mostraría el historial de préstamos de un libro específico.");
    Pausa();
}

static void ReportOverdue()
{
    Console.Clear();
    Console.WriteLine("PRÉSTAMOS VENCIDOS");
    Console.WriteLine("→ Aquí se mostrarían los préstamos cuya fecha de devolución ya pasó.");
    Pausa();
}

static void ReportSummary()
{
    Console.Clear();
    Console.WriteLine("RESUMEN GENERAL");
    Console.WriteLine("→ Total libros, usuarios, préstamos activos y préstamos vencidos.");
    Pausa();
}

// MENÚ GUARDAR / CARGAR

static void ShowPersistenceMenu()
{
    int opcion = 0;
    while (opcion != 4)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║     GUARDAR / CARGAR         ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  1. Guardar datos            ║");
        Console.WriteLine("║  2. Cargar datos             ║");
        Console.WriteLine("║  3. Reiniciar datos          ║");
        Console.WriteLine("║  4. Volver                   ║");
        Console.WriteLine("╚══════════════════════════════╝");
        opcion = LeerOpcion("Seleccione una opción: ", 1, 4);

        switch (opcion)
        {
            case 1: SaveData();          break;
            case 2: LoadData();          break;
            case 3: ConfirmResetData();  break;
            case 4: return;
        }
    }
}

static void SaveData()
{
    Console.Clear();
    Console.WriteLine("GUARDAR DATOS");
    Console.WriteLine("→ Aquí se guardarían todos los datos del sistema en un archivo.");
    Pausa();
}

static void LoadData()
{
    Console.Clear();
    Console.WriteLine("CARGAR DATOS");
    Console.WriteLine("→ Aquí se cargarían los datos previamente guardados desde un archivo.");
    Pausa();
}

static void ResetData()
{
    Console.Clear();
    Console.WriteLine("REINICIAR DATOS");
    Console.WriteLine("→ Todos los datos del sistema han sido reiniciados.");
    Pausa();
}

static void ConfirmResetData()
{
    Console.Clear();
    Console.WriteLine("¿Está seguro que desea reiniciar todos los datos? (S/N)");
    Console.Write("→ ");
    string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();
    if (respuesta == "S")
        ResetData();
    else
        Console.WriteLine(" Operación cancelada.");
    Pausa();
}