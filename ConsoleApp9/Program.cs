
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string direccion = "C:/Users/csi23-salflet/source/repos/ConsoleApp9";

            mostrarContenidoCarpeta(direccion);

            string rutaArchivo = mostrarContenidoTxt();

            int[] menu = menuSeleccion();
            int numeroLinea = menu[0];
            int seleccion = menu[1];

            switch (seleccion)
            {
                case 1:
                    lineaCompleta(rutaArchivo, numeroLinea);
                    break;

                case 2:
                    posicionEspecifica(rutaArchivo, numeroLinea);
                    break;
            }
        }
    }

    public static int[] menuSeleccion()
    {

        int[] lineaSelecicon = new int[2];

        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("");

        Console.WriteLine("Ingrese la linea que se desea editar");
        lineaSelecicon[0] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("1.modificar una línea específica");
        Console.WriteLine("2.insertar texto en una posición específica de una línea");
        lineaSelecicon[1] = Convert.ToInt32(Console.ReadLine());

        return lineaSelecicon;

    }

    public static void mostrarContenidoCarpeta(string direccion)
    {

        DirectoryInfo carpeta = new DirectoryInfo(direccion);
        Console.WriteLine("Archivos .txt      ");
        Console.WriteLine("===================");
        foreach (FileInfo flInfo in carpeta.GetFiles())
        {
            String name = flInfo.Name;

            if (name.EndsWith(".txt"))
            {

                Console.WriteLine(name);

            }
        }

    }

    private static string mostrarContenidoTxt()
    {

        Console.WriteLine("Ingreasa el nombre del archivo (solo el nombre)");
        string rutaArchivo = "C:/Users/csi23-salflet/source/repos/ConsoleApp9/" + Console.ReadLine() + ".txt";

        using (StreamReader sr = new StreamReader(rutaArchivo))
        {
            string line;
            // Leer y mostrar cada línea del archivo
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        return rutaArchivo;

    }

    private static void lineaCompleta(string rutaArchivo, int numeroLinea)
    {

        string[] lineas = File.ReadAllLines(rutaArchivo);

        try
        {
            // Verificar si el número de línea deseado está dentro del rango del archivo
            if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
            {
                Console.WriteLine("Contenido:");
                string textoNuevo = Console.ReadLine();

                // Reemplazar el contenido de la línea específica
                lineas[numeroLinea - 1] = textoNuevo;

                // Sobrescribir el archivo con las líneas actualizadas
                File.WriteAllLines(rutaArchivo, lineas);

                Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
            }
            else
            {
                Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void posicionEspecifica(string rutaArchivo, int numeroLinea)
    {
        Console.WriteLine("Ingrese la posicion que se desea sobreescribir");
        int posicion = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Contenido:");
        string textoNuevo = Console.ReadLine();

        // Leer todas las líneas del archivo
        string[] lineas = File.ReadAllLines(rutaArchivo);

        try
        {
            // Verificar si el número de línea deseado está dentro del rango del archivo
            if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
            {
                // Reemplazar el contenido de la línea específica
                lineas[numeroLinea - 1] = lineas[numeroLinea - 1].Insert(posicion, textoNuevo);

                // Sobrescribir el archivo con las líneas actualizadas
                File.WriteAllLines(rutaArchivo, lineas);

                Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
            }
            else
            {
                Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}



