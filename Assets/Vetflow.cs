using Veterinaria.Controllers;

namespace Veterinaria.Assets;

public class Vetflow
{
    public static void AddVet()
    {
        Console.WriteLine("====== Agregar Veterinario ======");
        var Vet = new Veterinarian();

        string name;
        do
        {
            Console.WriteLine("Ingrese el nombre del Veterinario: ");
            name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacio");
            }
        } while (string.IsNullOrEmpty(name));

        Vet.Name = name;
        var isCreated = VetController.Add(Vet);
        Console.WriteLine(isCreated ? "Veterinario agregado con éxito." : "No se pudo agregar el usuario.");
    }
    
    public static void ListVets()
    {
        Console.WriteLine("====== Lista de Veterinarios ======");
        var vets = VetController.GetAll();

        if (vets.Count == 0)
        {
            Console.WriteLine("No hay veterinarios registrados");
        }
        else
        {
            Console.WriteLine("Lista de veterinarios:");
            vets.ForEach(u => Console.WriteLine($"ID: {u.Id} || {u.Name}"));
        }
    }
    
    public static void EditVet()
    {
        Console.WriteLine("====== Editar Veterinario ======");
        var editedVet = new Client();
        int editId = ReadIdInput("Escribe el ID del veterinario registrado"); 
        bool exist = ClientController.Check(editId);
        string name;
        if (exist)
        {
            do
            {
                Console.WriteLine("Ingrese el nombre del veterinario: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            editedVet.Name = name;
            var isChanged = ClientController.Edit(editId, editedVet);
            Console.WriteLine(isChanged ? "veterinario editado exitosamente" : "El usuario no se pudo editar");
            
        }
        else
        {
            Console.WriteLine("Este veterinario no está registrado en la base de datos, por tanto, no se puede editar");
        }
    }
    
    public static void DeleteVet()
    {
        Console.WriteLine("====== Eliminar Veterinario ======");
        int deleteId = ReadIdInput("Escribe el ID del veterinario a eliminar"); 
        bool exist = VetController.Check(deleteId);
        if (exist)
        {
            var isDeleted = VetController.Delete(deleteId);
            Console.WriteLine(isDeleted ? "Veterinario eliminado exitosamente" : "No se pudo eliminar, intenta nuevamente");
        }
        else
        {
            Console.WriteLine("Este veterinario no está registrado en la base de datos, por tanto, no se puede eliminar");
        }
    }
    
    
    private static int ReadIdInput(string prompt)
    {
        string? input;
        while (true)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("El valor no puede estar vacío.");
                continue;
            }


            if (!input.All(char.IsDigit))
            {
                Console.WriteLine("Sólo se permiten números.");
                continue;
            }

            return int.Parse(input);
        }
    }
}