using System;


// EJERCICIO 1

// clase abstracta contenido que va a ser la clase padre 
public abstract class Contenido
{

    // atributos privados para mantener la encapsulacion
    private string titulo;

    private double duracion;

    // atributos privados que implementan la encapsulacion
    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }

    }

    public double Duracion
    {
        get { return duracion; }
        set { duracion = (value <1) ? 1 : value; }
    }

    // constructor que van a contener todas las clases hijas que hereden de contenido
    protected Contenido(string titulo, double duracion)
    {
        Duracion = duracion;
        Titulo = titulo;
    }

    // metodos abstractos que seran utilizados en las clases hijas que hereden de ella
    public abstract double ObtenerTasaCompresion();
    public abstract string Describir();
    public abstract void Reproducir();

    
}


// EJERCICIO 2
// clase abstracta que va a ser la clase padre de todo el
// contenido audiovisual de nuestro programa

// clase que hereda los atributos de contenido ( mostrados en el 
// constructor
public abstract class ContenidoVisual : Contenido
{
    // atributos privados para mantener la encapsulacion
    private int resolucion;

    // atributo privado que implementa la encapsulacion
    public int Resolucion
    {
        get { return resolucion;}
        set { resolucion = value; }
    }

    // constructor que hereda los atributos de la clase padre
    // e inicia los suyos propios que heredaran sus clases hijas
    public ContenidoVisual(string titulo, double duracion, int resolucion) : base(titulo, duracion)
    {
        Resolucion = resolucion;
    }

    // clase heredada  y  modificada de la clase contenido
    public override double ObtenerTasaCompresion()
    {
        if (Resolucion >= 2160)
        {
            double valor = 0.6;
            return valor;
            
        }
        else
        {
            double valor = 0.9;
            return valor;
            
        }
    }
}
// EJERCICIO 3

// clase abstracta que va a ser la clase padre de todo el
// contenido auditivo de nuestro programa

// clase que hereda los atributos de contenido ( mostrados en el 
// constructor
public abstract class ContenidoAuditivo : Contenido
{
    
    private int bitrate;

    // atributo privado que implementa la encapsulacion
    public int Bitrate
    {
        get { return bitrate; }
        set { bitrate = value; }
    }

    // constructor que hereda los atributos de la clase padre
    // e inicia los suyos propios que heredaran sus clases hijas
    public ContenidoAuditivo(string titulo, double duracion, int bitrate) : base(titulo, duracion)
    {
        Bitrate = bitrate;
    }

    // clase heredada  y  modificada de la clase contenido
    public override double ObtenerTasaCompresion()
    {
        return 1.0 - (Bitrate / 500);
    }
}


// EJERCICIO 4

// clase hija que hereda los atributos de contenido 
//  ( mostrados en el constructor)
public class Peliculas : ContenidoVisual
{

    
    private string director;


    // atributo privado que implementa la encapsulacion
    public string Director
    {
        get { return director; }
        set
        {
            if (value.Length < 5)
                director = "Desconocido";
            else
                director = value;
        }
    }

    // claro ejemplo de la herencia que encontramos de contenido visual
    // constructor que hereda los atributos de la clase padre
    // e inicia los suyos propios
    public Peliculas(string titulo, double duracion, int resolucion, string director) : base(titulo, duracion, resolucion)
    {
        Director = director;
    }

    // metodos heredados y sobreescritos de la clase contenido que
    // utilizaremos para mostrar un contenido especifico
    public override string Describir()
    {
        return $"PELÍCULA: {Titulo} ({Duracion} minutos)";
    }

    public override void Reproducir()
    {
        Console.WriteLine();
        Console.WriteLine($"*** INICIO DE PELICULA: {Titulo} ***");
        Console.WriteLine("[INFO] Cargando componentes visuales...");
        Console.WriteLine($"[CRÉDITO] Director: {director}");
        if(Duracion < 60)
        {
            Console.WriteLine("--> Es un cortometraje");
        }
        Console.WriteLine($"[INFO] Tasa de compresión reportada: {ObtenerTasaCompresion()}");
        Console.WriteLine($"*** REPRODUCCION FINALIZADA : {Titulo}");
        Console.WriteLine();
    }
}

// EJERCICIO 5

// claro ejemplo de la herencia que encontramos de contenido auditivo
// constructor que hereda los atributos de la clase padre
// e inicia los suyos propios
public class Canciones : ContenidoAuditivo
{
    private string licencia;

    public string Licencia
    {
        get { return licencia; }
        set { licencia = value; }
    }
    // constructor que hereda los atributos de la clase padre
    // e inicia los suyos propios
    public Canciones(string titulo, double duracion, int bitrate, string licencia) : base(titulo, duracion, bitrate)
    {
        Licencia = licencia;
    }
    // metodos heredados y sobreescritos de la clase contenido que
    // utilizaremos para mostrar un contenido especifico
    public override string Describir()
    {
        return $"CANCIÓN: {Titulo} ({Duracion} minutos)";
    }

    public override void Reproducir()
    {
        Console.WriteLine();
        Console.WriteLine($"*** INICIO DE CANCIÓN: {Titulo} ***");
        Console.WriteLine($"[INFO] Bitrate utilizado: {Bitrate}");
        if(licencia == "protegida")
        {
            Console.WriteLine("¡ADVERTENCIA! Pago de royalties aplicado");

        }

        Console.WriteLine($"[INFO] Tasa de compresion reportada: {ObtenerTasaCompresion()}");
        Console.WriteLine($"*** REPRODUCCIÓN FINALIZADA: {Titulo} ***");
        Console.WriteLine();

    }
}

public class Program
{
    public static void Main(string[] args)
    {

        // lista de contenido que metemos demntro de nuestro programa
        List<Contenido> contenido = new List<Contenido>(){
                new Peliculas("Interstellar", 169, 2160, "Christopher Nolan"),
                new Peliculas("Feast", 7, 480, "Patrick Osborne"),
                new Canciones("Bohemian Rhapsody", 6, 320, "protegida"),
                new Canciones("The House of the Rising Sun", 5, 128, "libre"),
                new Peliculas("Pelicula Ejemplo 1", 127, 1080, "Director no se"),
                new Peliculas("Pelicula Ejemplo 2", 45, 720, "Pep"),
                new Canciones("Cancion Ej 1", 3, 182, "protegida"),
                new Canciones("Cancion Ej 2", 0.5, 256, "libre")
            };

        bool salir = false;

        while (!salir)

            // menu del programa
        {
            Console.WriteLine();
            Console.WriteLine("SISTEMA DE CONTENIDO");
            Console.WriteLine("1. Ver catalogo");
            Console.WriteLine("2. Reproducir");
            Console.WriteLine("3. Terminar");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion:");
            string opcion = Console.ReadLine();

            // utilizamos los metodos dentro del programa

            switch (opcion)
            {
                case "1":
                    foreach (var cont in contenido)
                    {
                        Console.WriteLine(cont.Describir()); 
                    }
                    break;
                case "2":
                    foreach (var cont in contenido)
                    {
                        cont.Reproducir();
                    }
                    break;
                case "3":
                    Console.WriteLine("Saliendo de la aplicacion...");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opcion no valida, intente de nuevo");
                    break;
            }
        }
    }
}



