const string NombreComercio = "KIOSCO EL RECREO";
const decimal PorcentajeDescuentoAlto = 0.10m;
const decimal PorcentajeDescuentoMedio = 0.05m;
const decimal UmbralDescuentoAlto = 50000;
const decimal UmbralDescuentoMedio = 20000;

Console.WriteLine($"=== {NombreComercio} ===");

Console.Write("Nombre del cajero: ");
string nombreCajero = Console.ReadLine();

Console.WriteLine($"Bienvenida, {nombreCajero}. Caja abierta.");

decimal total = 0;
int cantidadProductos = 0;
int opcion;

do
{
    Console.WriteLine();
    Console.WriteLine("¿Qué desea hacer?");
    Console.WriteLine("1 - Cargar un producto");
    Console.WriteLine("2 - Cerrar la venta");
    Console.Write("Opción: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.Write("Nombre del producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Precio: ");
            decimal precioProducto = decimal.Parse(Console.ReadLine());

            total += precioProducto;
            cantidadProductos++;

            Console.WriteLine($"Producto cargado: {nombreProducto} - ${precioProducto}");
            break;

        case 2:
            Console.WriteLine("Cerrando venta...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (opcion != 2);

decimal subtotal = total;
decimal porcentajeDescuento;

if (subtotal > UmbralDescuentoAlto)
{
    porcentajeDescuento = PorcentajeDescuentoAlto;
}
else if (subtotal > UmbralDescuentoMedio)
{
    porcentajeDescuento = PorcentajeDescuentoMedio;
}
else
{
    porcentajeDescuento = 0;
}

decimal descuento = subtotal * porcentajeDescuento;
decimal totalConDescuento = subtotal - descuento;

Console.WriteLine();
Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
Console.WriteLine($"Subtotal: ${subtotal}");
Console.WriteLine($"Descuento aplicado: ${descuento}");
Console.WriteLine($"Total con descuento: ${totalConDescuento}");

Console.ReadLine();