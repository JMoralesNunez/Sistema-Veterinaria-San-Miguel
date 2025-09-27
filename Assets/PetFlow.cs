using Veterinaria.Controllers;

namespace Veterinaria.Assets;

public abstract class PetFlow
{
    public static void AddPet()
    {
        Console.WriteLine("====== Agregar Máscota ======");
        var pet = new Pet();

        string name;
        do
        {
            Console.WriteLine("Ingrese el nombre de la máscota: ");
            name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacio");
            }
        } while (string.IsNullOrEmpty(name));
        
        //Get the client related to the pet:
        Console.WriteLine("Elige al dueño de la mascota: ");
        ClientFlow.ListClients();
        int id = ReadIdInput("Escribe el ID del cliente: ");
        bool exist = ClientController.Check(id);
        if (exist)
        {
            pet.Name = name;
            pet.ClientId = id;
            var isCreated = PetController.Add(pet);
            Console.WriteLine(isCreated ? "Mascota agregada con éxito." : "No se pudo agregar la Mascota.");
        }
        else
        {
            Console.WriteLine("El Id ingresado no pertenece a ningún cliente registrado, intenta nuevamente con un Id válido");
        }
        
    }
    
    public static void ListPets()
    {
        Console.WriteLine("====== Lista de Mascotas ======");
        var pets = PetController.GetAll();

        if (pets.Count == 0)
        {
            Console.WriteLine("No hay mascotas registradas");
        }
        else
        {
            Console.WriteLine("Lista de mascotas:");
            pets.ForEach(u => Console.WriteLine($"ID: {u.Id} || {u.Name} || Dueño: {u.Client.Name}"));
        }
    }
    
    public static void EditPet()
    {
        Console.WriteLine("====== Editar Mascota ======");
        var editedPet = new Pet();
        int editId = ReadIdInput("Escribe el ID de la mascota registrada"); 
        bool exist = PetController.Check(editId);
        string name;
        if (exist)
        {
            do
            {
                Console.WriteLine("Ingrese el nuevo nombre de la mascota: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            
            Console.WriteLine("Elige al dueño de la mascota: ");
            ClientFlow.ListClients();
            int id = ReadIdInput("Escribe el ID del cliente: ");
            bool existClient = ClientController.Check(id);
            if (existClient)
            {
                editedPet.Name = name;
                editedPet.ClientId = id;
                var isChanged = PetController.Edit(editId, editedPet);
                Console.WriteLine(isChanged ? "Mascota editada con éxito." : "No se pudo editar la Mascota.");
            }
            else
            {
                Console.WriteLine("El Id ingresado no pertenece a ningún cliente registrado, intenta nuevamente con un Id válido");
            }
        }
        else
        {
            Console.WriteLine("Esta mascota no está registrada en la base de datos, por tanto, no se puede editar");
        }
    }
    
    public static void DeletePet()
    {
        Console.WriteLine("====== Eliminar Mascota ======");
        int deleteId = ReadIdInput("Escribe el ID de la mascota a eliminar"); 
        bool exist = PetController.Check(deleteId);
        if (exist)
        {
            var isDeleted = PetController.Delete(deleteId);
            Console.WriteLine(isDeleted ? "Mascota eliminada exitosamente" : "No se pudo eliminar, intenta nuevamente");
        }
        else
        {
            Console.WriteLine("Esta mascota no está registrada en la base de datos, por tanto, no se puede eliminar");
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