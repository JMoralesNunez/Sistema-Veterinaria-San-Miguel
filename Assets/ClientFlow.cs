using Veterinaria.Controllers;

namespace Veterinaria.Assets;

public abstract class ClientFlow
{
    public static void AddClient()
    {
        Console.WriteLine("====== Agregar Cliente ======");
        Client client = new Client();

        string? name;
        do
        {
            Console.WriteLine("Ingrese el nombre del cliente: ");
            name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacio");
            }
        } while (string.IsNullOrEmpty(name));

        client.Name = name;
        var isCreated = ClientController.Add(client);
        Console.WriteLine(isCreated ? "Usuario agregado con éxito." : "No se pudo agregar el usuario.");
    }

    public static void ListClients()
    {
        Console.WriteLine("====== Lista de Clientes ======");
        var clients = ClientController.GetAll();

        if (clients.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados");
        }
        else
        {
            Console.WriteLine("Lista de clientes:");
            clients.ForEach(u => Console.WriteLine($"ID: {u.Id} || {u.Name}"));
        }
    }

    public static void EditClient()
    {
        Console.WriteLine("====== Editar Cliente ======");
        var editedClient = new Client();
        int editId = ReadIdInput("Escribe el ID del cliente registrado"); 
        bool exist = ClientController.Check(editId);
        string name;
        if (exist)
        {
            do
            {
                Console.WriteLine("Ingrese el nuevo nombre del cliente: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            editedClient.Name = name;
            var isChanged = ClientController.Edit(editId, editedClient);
            Console.WriteLine(isChanged ? "Usuario editado exitosamente" : "El usuario no se pudo editar");
            
        }
        else
        {
            Console.WriteLine("Este cliente no está registrado en la base de datos, por tanto, no se puede editar");
        }
    }

    public static void DeleteClient()
    {
        Console.WriteLine("====== Eliminar Cliente ======");
        int deleteId = ReadIdInput("Escribe el ID del cliente a eliminar"); 
        bool exist = ClientController.Check(deleteId);
        if (exist)
        {
            var isDeleted = ClientController.Delete(deleteId);
            Console.WriteLine(isDeleted ? "Cliente eliminado exitosamente" : "No se pudo eliminar, intenta nuevamente");
        }
        else
        {
            Console.WriteLine("Este cliente no está registrado en la base de datos, por tanto, no se puede eliminar");
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
