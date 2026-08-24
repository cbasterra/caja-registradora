const string NombreComercio = "KIOSCO EL RECREO";
const decimal PorcentajeDescuentoAlto = 0.10m;
const decimal PorcentajeDescuentoMedio = 0.05m;
const decimal UmbralDescuentoAlto = 50000;
const decimal UmbralDescuentoMedio = 20000;
const decimal PorcentajeDescuentoEfectivo = 0.10m;
const decimal PorcentajeRecargoCredito = 0.15m;

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

int medioPago = 0;
bool medioPagoValido = false;

do
{
    Console.WriteLine();
    Console.WriteLine("Medio de pago:");
    Console.WriteLine("1 - Efectivo");
    Console.WriteLine("2 - Débito");
    Console.WriteLine("3 - Crédito");
    Console.Write("Opción: ");
    medioPago = int.Parse(Console.ReadLine());

    switch (medioPago)
    {
        case 1:
        case 2:
        case 3:
            medioPagoValido = true;
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (!medioPagoValido);

decimal recargo = 0;
decimal totalFinal = totalConDescuento;

switch (medioPago)
{
    case 1:
        decimal descuentoEfectivo = totalConDescuento * PorcentajeDescuentoEfectivo;
        totalFinal = totalConDescuento - descuentoEfectivo;
        break;
    case 2:
        totalFinal = totalConDescuento;
        break;
    case 3:
        recargo = totalConDescuento * PorcentajeRecargoCredito;
        totalFinal = totalConDescuento + recargo;
        break;
}

Console.WriteLine();

string linea = "";
for (int i = 0; i < 30; i++)
{
    linea += "-";
}

Console.WriteLine(linea);
Console.WriteLine($"       {NombreComercio}");
Console.WriteLine(linea);
Console.WriteLine($"Cajero: {nombreCajero}");
Console.WriteLine($"Productos: {cantidadProductos}");
Console.WriteLine($"Subtotal: {subtotal}");
Console.WriteLine($"Descuento: {descuento}");
Console.WriteLine($"Recargo: {recargo}");
Console.WriteLine(linea);
Console.WriteLine($"TOTAL: {totalFinal}");
Console.WriteLine(linea);

Console.ReadLine();