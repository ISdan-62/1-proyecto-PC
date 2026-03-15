int opcion = 0;
do
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    Console.WriteLine("Elegir la opcion a realizar: ");
    opcion=int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            {
                break;
            }
        case 2:
            {
                break;
            }
        case 3:
            {
                break;
            }
        case 4:
            {
                break;
            }
        case 5:
            {
                Console.WriteLine("Salida");
                break;
            }
        default:
            {
                Console.WriteLine("Opcion Invalida");
                break;
            }
    }
} while (opcion != 5);