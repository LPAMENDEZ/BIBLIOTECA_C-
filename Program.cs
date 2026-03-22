
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