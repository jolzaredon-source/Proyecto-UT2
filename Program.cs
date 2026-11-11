
namespace UT2Proyecto;

class Program
{
    static void Main(string[] args)
    {
        int operaciones = 0, opcion = 0;
        double recaudacion = 0, maximo = 0;
        string clienteMaximo = "";

        do
        {
            Console.WriteLine("\n--- TIENDA INFORMATICA ---");
            Console.WriteLine("1. Nueva operacion");
            Console.WriteLine("2. Consultar caja");
            Console.WriteLine("3. Salir");
            Console.Write("Selecciona una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Opcion no valida.");
                continue;
            }

            if (opcion == 1)
            {
                string cliente = "", producto = "", listaExtras = "", direccion = "";
                double precio = 0, extras = 0, suplemento = 0, entregado = 0;
                int numExtras = 0;

                bool sistema = false, limpieza = false, garantia = false;

                // CLIENTE
                do
                {
                    Console.Write("Nombre del cliente: ");
                    cliente = (Console.ReadLine() ?? "").Trim();
                } while (cliente == "");

                // SERVICIO
                int servicio = 0;

                while (servicio < 1 || servicio > 2)
                {
                    Console.WriteLine("\n--- SERVICIOS ---");
                    Console.WriteLine("1. Comprar componentes");
                    Console.WriteLine("2. Montar ordenador");
                    Console.Write("Selecciona una opcion: ");

                    int.TryParse(Console.ReadLine(), out servicio);

                    if (servicio < 1 || servicio > 2)
                        Console.WriteLine("Opcion no valida.");
                }

                // COMPONENTES
                if (servicio == 1)
                {
                    int componente = 0;

                    while (componente < 1 || componente > 5)
                    {
                        Console.WriteLine("\n--- COMPONENTES ---");
                        Console.WriteLine("1. Procesador - 180 euros");
                        Console.WriteLine("2. Tarjeta grafica - 300 euros");
                        Console.WriteLine("3. Memoria RAM - 60 euros");
                        Console.WriteLine("4. Disco SSD - 70 euros");
                        Console.WriteLine("5. Fuente de alimentacion - 80 euros");
                        Console.Write("Que componente necesitas: ");

                        int.TryParse(Console.ReadLine(), out componente);

                        if (componente < 1 || componente > 5)
                            Console.WriteLine("Opcion no valida.");
                    }

                    switch (componente)
                    {
                        case 1: producto = "Procesador"; precio = 180; break;
                        case 2: producto = "Tarjeta grafica"; precio = 300; break;
                        case 3: producto = "Memoria RAM"; precio = 60; break;
                        case 4: producto = "Disco SSD"; precio = 70; break;
                        case 5: producto = "Fuente de alimentacion"; precio = 80; break;
                    }
                }
                // MONTAJE
                else
                {
                    int uso = 0;
                    double presupuesto = 0;

                    while (uso < 1 || uso > 3)
                    {
                        Console.WriteLine("\n--- USO DEL ORDENADOR ---");
                        Console.WriteLine("1. Gaming");
                        Console.WriteLine("2. Trabajo");
                        Console.WriteLine("3. Estudios");
                        Console.Write("Para que necesitas el ordenador: ");

                        int.TryParse(Console.ReadLine(), out uso);

                        if (uso < 1 || uso > 3)
                            Console.WriteLine("Opcion no valida.");
                    }

                    switch (uso)
                    {
                        case 1: producto = "Montaje de ordenador gaming"; break;
                        case 2: producto = "Montaje de ordenador para trabajo"; break;
                        case 3: producto = "Montaje de ordenador para estudios"; break;
                    }

                    while (presupuesto <= 0)
                    {
                        Console.Write("Que presupuesto tienes en euros: ");

                        if (!double.TryParse(Console.ReadLine(), out presupuesto) || presupuesto <= 0)
                        {
                            presupuesto = 0;
                            Console.WriteLine("Presupuesto no valido.");
                        }
                    }

                    precio = 80;

                    Console.WriteLine("\n--- RESUMEN ---");
                    Console.WriteLine("Servicio: " + producto);
                    Console.WriteLine("Presupuesto: " + presupuesto + " euros");
                    Console.WriteLine("Precio del montaje: " + precio + " euros");
                }

                // EXTRAS
                int extra = 0;

                while (extra != 4)
                {
                    Console.WriteLine("\n--- EXTRAS ---");
                    Console.WriteLine("1. Sistema operativo - 25 euros");
                    Console.WriteLine("2. Limpieza - 15 euros");
                    Console.WriteLine("3. Garantia ampliada - 30 euros");
                    Console.WriteLine("4. Terminar");
                    Console.Write("Selecciona un extra: ");

                    int.TryParse(Console.ReadLine(), out extra);

                    if (extra < 1 || extra > 4)
                        Console.WriteLine("Opcion no valida.");
                    else if (extra == 1 && !sistema)
                    {
                        sistema = true;
                        extras += 25;
                        listaExtras += "[Sistema operativo] ";
                        numExtras++;
                    }
                    else if (extra == 2 && !limpieza)
                    {
                        limpieza = true;
                        extras += 15;
                        listaExtras += "[Limpieza] ";
                        numExtras++;
                    }
                    else if (extra == 3 && !garantia)
                    {
                        garantia = true;
                        extras += 30;
                        listaExtras += "[Garantia ampliada] ";
                        numExtras++;
                    }
                    else if (extra != 4 && extra >= 1 && extra <= 3)
                        Console.WriteLine("Ese extra ya esta anadido.");

                    if (extra >= 1 && extra <= 3)
                    {
                        Console.WriteLine("Extras elegidos: " + numExtras);
                        Console.WriteLine("Importe provisional: " + (precio + extras) + " euros");
                    }
                }

                // ENTREGA
                int entrega = 0;

                while (entrega < 1 || entrega > 2)
                {
                    Console.WriteLine("\n--- ENTREGA ---");
                    Console.WriteLine("1. Recoger en tienda");
                    Console.WriteLine("2. Entrega a domicilio (+10 euros)");
                    Console.Write("Selecciona una opcion: ");

                    int.TryParse(Console.ReadLine(), out entrega);

                    if (entrega < 1 || entrega > 2)
                        Console.WriteLine("Opcion no valida.");
                }

                if (entrega == 2)
                {
                    suplemento = 10;
                    Console.Write("Introduce la direccion: ");
                    direccion = Console.ReadLine() ?? "";
                }

                // PRECIO Y DESCUENTO
                double subtotal = precio + extras + suplemento;
                double descuento = subtotal >= 150 ? subtotal * 0.10 : 0;
                double total = subtotal - descuento;

                // PAGO
                Console.WriteLine("\nTotal a pagar: " + total + " euros");

                while (entregado < total)
                {
                    Console.Write("Dinero entregado: ");

                    if (!double.TryParse(Console.ReadLine(), out entregado) || entregado < total)
                    {
                        entregado = 0;
                        Console.WriteLine("Dinero insuficiente o incorrecto.");
                    }
                }

                double cambio = entregado - total;

                // TICKET
                Console.WriteLine("\n========== TICKET ==========");
                Console.WriteLine("Cliente: " + cliente);
                Console.WriteLine("Servicio: " + producto);
                Console.WriteLine("Extras: " + listaExtras);
                Console.WriteLine("Precio: " + precio + " euros");
                Console.WriteLine("Extras: " + extras + " euros");
                Console.WriteLine("Entrega: " + suplemento + " euros");

                if (entrega == 2)
                    Console.WriteLine("Direccion: " + direccion);

                Console.WriteLine("Subtotal: " + subtotal + " euros");
                Console.WriteLine("Descuento: " + descuento + " euros");
                Console.WriteLine("TOTAL: " + total + " euros");
                Console.WriteLine("Entregado: " + entregado + " euros");
                Console.WriteLine("Cambio: " + cambio + " euros");
                Console.WriteLine("============================");

                // ACTUALIZAR CAJA
                operaciones++;
                recaudacion += total;

                if (total > maximo)
                {
                    maximo = total;
                    clienteMaximo = cliente;
                }
            }
            // CONSULTAR CAJA
            else if (opcion == 2)
            {
                Console.WriteLine("\n--- CAJA ---");
                Console.WriteLine("Operaciones cobradas: " + operaciones);
                Console.WriteLine("Recaudacion: " + recaudacion + " euros");

                if (operaciones > 0)
                {
                    Console.WriteLine("Importe medio: " + (recaudacion / operaciones) + " euros");
                    Console.WriteLine("Mayor operacion: " + maximo + " euros");
                    Console.WriteLine("Cliente: " + clienteMaximo);
                }
                else
                    Console.WriteLine("Todavia no hay operaciones.");
            }

        } while (opcion != 3);

        Console.WriteLine("\nGracias por visitar la tienda.");
    }
}
