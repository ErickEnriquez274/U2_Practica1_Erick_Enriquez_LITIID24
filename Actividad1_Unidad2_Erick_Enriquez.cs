using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> nombres = new List<string>();
        List<int> edades = new List<int>();

        int cantidadPersonas = 0;
        bool entradaValida = false;

        // Solicitar cantidad de personas con validación
        while (!entradaValida)
        {
            Console.Write("Ingrese la cantidad de personas a registrar (mínimo 1): ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out cantidadPersonas) && cantidadPersonas >= 1)
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("¡Valor no válido! Debe ingresar un número entero mayor o igual a 1.");
                Console.WriteLine("Intente nuevamente.\n");
            }
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine($"Se registrarán {cantidadPersonas} persona(s)");
        Console.WriteLine("========================================\n");

        // Registrar datos de cada persona
        for (int i = 0; i < cantidadPersonas; i++)
        {
            Console.WriteLine($"--- Persona {i + 1} ---");

            // Solicitar nombre
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            // Validar que el nombre no esté vacío
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("El nombre no puede estar vacío. Ingrese nombre: ");
                nombre = Console.ReadLine();
            }

            // Solicitar edad con validación
            int edad = 0;
            bool edadValida = false;

            while (!edadValida)
            {
                Console.Write("Edad: ");
                string entradaEdad = Console.ReadLine();

                if (int.TryParse(entradaEdad, out edad) && edad >= 0)
                {
                    edadValida = true;
                }
                else
                {
                    Console.WriteLine("¡Edad no válida! Debe ingresar un número entero no negativo.");
                    Console.WriteLine("Intente nuevamente.");
                }
            }

            nombres.Add(nombre);
            edades.Add(edad);

            Console.WriteLine(); // Línea en blanco para separar
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("RESULTADOS");
        Console.WriteLine(new string('=', 50));

        // CASO ESPECIAL: Solo una persona
        if (cantidadPersonas == 1)
        {
            Console.WriteLine("\n--- CASO DE UNA SOLA PERSONA ---");
            Console.WriteLine($"Nombre: {nombres[0]}");
            Console.WriteLine($"Edad: {edades[0]} años");

            if (edades[0] >= 18)
            {
                Console.WriteLine("Estado: MAYOR DE EDAD");
            }
            else
            {
                Console.WriteLine("Estado: MENOR DE EDAD");
            }
        }
        // CASO GENERAL: Dos o más personas
        else
        {
            Console.WriteLine("\n--- LISTA GENERAL ---");
            for (int i = 0; i < cantidadPersonas; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - {edades[i]} años");
            }

            // Clasificar personas
            List<string> mayoresNombres = new List<string>();
            List<int> mayoresEdades = new List<int>();
            List<string> menoresNombres = new List<string>();
            List<int> menoresEdades = new List<int>();

            for (int i = 0; i < cantidadPersonas; i++)
            {
                if (edades[i] >= 18)
                {
                    mayoresNombres.Add(nombres[i]);
                    mayoresEdades.Add(edades[i]);
                }
                else
                {
                    menoresNombres.Add(nombres[i]);
                    menoresEdades.Add(edades[i]);
                }
            }

            // Mostrar listados (solo si contienen datos)
            Console.WriteLine("\n" + new string('-', 50));

            if (mayoresNombres.Count > 0)
            {
                Console.WriteLine("\n--- PERSONAS MAYORES DE EDAD (18 años o más) ---");
                for (int i = 0; i < mayoresNombres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {mayoresNombres[i]} - {mayoresEdades[i]} años");
                }
            }

            if (menoresNombres.Count > 0)
            {
                Console.WriteLine("\n--- PERSONAS MENORES DE EDAD (menos de 18 años) ---");
                for (int i = 0; i < menoresNombres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menoresNombres[i]} - {menoresEdades[i]} años");
                }
            }
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("PROGRAMA FINALIZADO");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}