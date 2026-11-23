using System;
using System.Collections.Generic;

class Program
{
    // DELEGADOS
    delegate int Multiplicar(int a, int b);
    delegate bool VerificarPalindromo(string palabra);
    delegate double ConvertirTemperatura(double celsius);
    delegate bool EsMayorQueDiez(int numero);
    delegate bool CompararLongitud(string palabra1, string palabra2);
    delegate int CalcularFactorial(int numero);
    delegate int ContarCaracteres(string palabra);
    delegate bool Operacion(int numero);
    delegate bool Filtro(Producto producto);
    delegate bool FiltroEmpleado(Empleado empleado);
    delegate bool FiltroLibros(Libro libro);
    delegate bool FiltroVehiculo(Vehiculo vehiculo);

    static void Main()
    {
        Ejercicio1();
        Ejercicio2();
        Ejercicio3();
        Ejercicio4();
        Ejercicio5();
        Ejercicio6();
        Ejercicio7();
        Ejercicio8();
        Ejercicio9();
        Ejercicio10();
        Ejercicio11();
        Ejercicio12();
    }

    // EJERCICIO 1
    static void Ejercicio1()
    {
        Console.WriteLine("=== EJERCICIO 1 ===");

        // Método anónimo: se escribe con la palabra delegate, sin nombre
        Multiplicar multiplicar = delegate (int a, int b)
        {
            return a * b;
        };

        int numero1 = 4;
        int numero2 = 3;
        int numero3 = 7;
        int numero4 = 5;

        Console.WriteLine($"{numero1} * {numero2} = {multiplicar(numero1, numero2)}");
        Console.WriteLine($"{numero3} * {numero4} = {multiplicar(numero3, numero4)}");
        Console.WriteLine();
    }

    // EJERCICIO 2
    static void Ejercicio2()
    {
        Console.WriteLine("=== EJERCICIO 2 ===");

        VerificarPalindromo verificar = delegate (string palabra)
        {
            for (int i = 0; i < palabra.Length / 2; i++)
            {
                if (palabra[i] != palabra[palabra.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        };

        Console.WriteLine($"'radar' es un palíndromo: {verificar("radar")}");
        Console.WriteLine($"'puerta' es un palíndromo: {verificar("puerta")}");
        Console.WriteLine();
    }

    // EJERCICIO 3
    static void Ejercicio3()
    {
        Console.WriteLine("=== EJERCICIO 3 ===");

        ConvertirTemperatura convertir = delegate (double celsius)
        {
            return celsius * 9 / 5 + 32;
        };

        Console.WriteLine($"0°C -> {convertir(0)}°F");
        Console.WriteLine($"30°C -> {convertir(30)}°F");
        Console.WriteLine();
    }

    // EJERCICIO 4
    static void Ejercicio4()
    {
        Console.WriteLine("=== EJERCICIO 4 ===");

        EsMayorQueDiez esMayor = delegate (int numero)
        {
            return numero > 10;
        };

        Console.WriteLine($"8 es mayor que 10: {esMayor(8)}");
        Console.WriteLine($"15 es mayor que 10: {esMayor(15)}");
        Console.WriteLine();
    }

    // EJERCICIO 5
    static void Ejercicio5()
    {
        Console.WriteLine("=== EJERCICIO 5 ===");

        CompararLongitud comparar = delegate (string palabra1, string palabra2)
        {
            return palabra1.Length == palabra2.Length;
        };

        Console.WriteLine($"Las palabras 'gato' y 'perro' tienen la misma longitud: {comparar("gato", "perro")}");
        Console.WriteLine();
    }

    // EJERCICIO 6
    static void Ejercicio6()
    {
        Console.WriteLine("=== EJERCICIO 6 ===");

        CalcularFactorial factorial = delegate (int numero)
        {
            int resultado = 1;
            for (int i = 1; i <= numero; i++)
            {
                resultado = resultado * i;
            }
            return resultado;
        };

        Console.WriteLine($"Factorial de 4 es {factorial(4)}");
        Console.WriteLine($"Factorial de 6 es {factorial(6)}");
        Console.WriteLine();
    }

    // EJERCICIO 7
    static void Ejercicio7()
    {
        Console.WriteLine("=== EJERCICIO 7 ===");

        ContarCaracteres contar = delegate (string palabra)
        {
            return palabra.Length;
        };

        Console.WriteLine($"La palabra 'mundo' tiene {contar("mundo")} caracteres");
        Console.WriteLine($"La palabra 'programa' tiene {contar("programa")} caracteres");
        Console.WriteLine();
    }

    // EJERCICIO 8
    static void Ejercicio8()
    {
        Console.WriteLine("=== EJERCICIO 8 ===");

        Operacion esPar = delegate (int numero)
        {
            return numero % 2 == 0;
        };

        ProcesarNumero(4, esPar);
        ProcesarNumero(7, esPar);
        Console.WriteLine();
    }

    static void ProcesarNumero(int numero, Operacion operacion)
    {
        bool resultado = operacion(numero);
        Console.WriteLine($"El número {numero} es par: {resultado}");
    }

    // EJERCICIO 9
    static void Ejercicio9()
    {
        Console.WriteLine("=== EJERCICIO 9 ===");

        List<Producto> productos = new List<Producto>();
        productos.Add(new Producto("Televisor", 10));
        productos.Add(new Producto("Refrigerador", 7));
        productos.Add(new Producto("Microondas", 3));

        int minimo = 5;

        Filtro filtro = delegate (Producto producto)
        {
            return producto.Cantidad > minimo;
        };

        Console.WriteLine($"Productos con cantidad mayor a {minimo}:");
        MostrarProductosFiltrados(productos, filtro);
        Console.WriteLine();
    }

    static void MostrarProductosFiltrados(List<Producto> productos, Filtro filtro)
    {
        foreach (Producto producto in productos)
        {
            if (filtro(producto))
            {
                Console.WriteLine($"- {producto.Nombre} (Cantidad: {producto.Cantidad})");
            }
        }
    }

    // EJERCICIO 10
    static void Ejercicio10()
    {
        Console.WriteLine("=== EJERCICIO 10 ===");

        List<Empleado> empleados = new List<Empleado>();
        empleados.Add(new Empleado("Ana", 35));
        empleados.Add(new Empleado("Luis", 42));
        empleados.Add(new Empleado("Carlos", 25));

        FiltroEmpleado filtro = delegate (Empleado empleado)
        {
            return empleado.Edad > 30;
        };

        Console.WriteLine("Empleados mayores de 30 años:");
        FiltrarEmpleados(empleados, filtro);
        Console.WriteLine();
    }

    static void FiltrarEmpleados(List<Empleado> empleados, FiltroEmpleado filtro)
    {
        foreach (Empleado empleado in empleados)
        {
            if (filtro(empleado))
            {
                Console.WriteLine($"- {empleado.Nombre} (Edad: {empleado.Edad})");
            }
        }
    }

    // EJERCICIO 11
    static void Ejercicio11()
    {
        Console.WriteLine("=== EJERCICIO 11 ===");

        List<Libro> libros = new List<Libro>();
        libros.Add(new Libro("El Hobbit", "Ficción"));
        libros.Add(new Libro("Breve historia del tiempo", "Ciencia"));
        libros.Add(new Libro("Harry Potter", "Ficción"));

        FiltroLibros filtro = delegate (Libro libro)
        {
            return libro.Categoria == "Ficción";
        };

        Console.WriteLine("Libros de la categoría Ficción:");
        MostrarLibrosPorCategoria(libros, filtro);
        Console.WriteLine();
    }

    static void MostrarLibrosPorCategoria(List<Libro> libros, FiltroLibros filtro)
    {
        foreach (Libro libro in libros)
        {
            if (filtro(libro))
            {
                Console.WriteLine($"- {libro.Titulo}");
            }
        }
    }

    // EJERCICIO 12
    static void Ejercicio12()
    {
        Console.WriteLine("=== EJERCICIO 12 ===");

        List<Vehiculo> vehiculos = new List<Vehiculo>();
        vehiculos.Add(new Vehiculo("Toyota", "Corolla", 2005));
        vehiculos.Add(new Vehiculo("Honda", "Civic", 2008));
        vehiculos.Add(new Vehiculo("Ford", "Focus", 2015));

        FiltroVehiculo filtro = delegate (Vehiculo vehiculo)
        {
            return vehiculo.AnioFabricacion < 2010;
        };

        Console.WriteLine("Vehículos fabricados antes de 2010:");
        MostrarVehiculosAntiguos(vehiculos, filtro);
    }

    static void MostrarVehiculosAntiguos(List<Vehiculo> vehiculos, FiltroVehiculo filtro)
    {
        foreach (Vehiculo vehiculo in vehiculos)
        {
            if (filtro(vehiculo))
            {
                Console.WriteLine($"- {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.AnioFabricacion})");
            }
        }
    }
}

// CLASES (ejercicios 9 al 12)
class Producto
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, int cantidad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
    }
}

class Empleado
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Empleado(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

class Libro
{
    public string Titulo { get; set; }
    public string Categoria { get; set; }

    public Libro(string titulo, string categoria)
    {
        Titulo = titulo;
        Categoria = categoria;
    }
}

class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnioFabricacion { get; set; }

    public Vehiculo(string marca, string modelo, int anioFabricacion)
    {
        Marca = marca;
        Modelo = modelo;
        AnioFabricacion = anioFabricacion;
    }
}