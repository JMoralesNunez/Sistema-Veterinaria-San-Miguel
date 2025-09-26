using Veterinaria.Controllers;

namespace Veterinaria.Assets;

public abstract class ClientFlow
{
    public static void AddClient()
    {
        Console.WriteLine("====== Agregar Cliente ======");
        var Client = new Client();

        string name;
        do
        {
            Console.WriteLine("Ingrese el nombre del cliente: ");
            name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacio");
            }
        } while (string.IsNullOrEmpty(name));

        Client.Name = name;
        var isCreated = ClientController.Add(Client);
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
}
