using Veterinaria.Data;
using Veterinaria.Controllers;
namespace Veterinaria.Assets;

public class Menu
{

    public void Start()
    {
        bool menu = true;
        while (menu)
        {
            Console.WriteLine("======Menú Principal======");
            Console.WriteLine("1. Gestión de clientes");
            Console.WriteLine("2. Gestión de Mascotas");
            Console.WriteLine("3. Gestión de Veterinarios");
            Console.WriteLine("4. Gestión de Atenciones Médicas");
            Console.WriteLine("5. Consultas avanzadas");
            Console.WriteLine("6. Salir");
            Console.WriteLine("Elige una opción: ");
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    bool clientMenu = true;
                    while (clientMenu)
                    {
                        Console.WriteLine("======Gestión de clientes======");
                        Console.WriteLine("1. Registrar cliente");
                        Console.WriteLine("2. Listar clientes");
                        Console.WriteLine("3. Editar cliente");
                        Console.WriteLine("4. Eliminar cliente");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("Elige una opcion: ");
                        string clientOption = Console.ReadLine();
                        switch (clientOption)
                        {
                            case "1":
                                ClientFlow.AddClient();
                                break;
                            case "2":
                                ClientFlow.ListClients();
                                break;
                            case "3":
                                ClientFlow.EditClient();
                                break;
                            case "4":
                                ClientFlow.DeleteClient();
                                break;
                            case "5":
                                clientMenu = false;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Elige una opción válida (1/5)");
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.Clear();
                    bool PetMenu = true;
                    while (PetMenu)
                    {
                        Console.WriteLine("======Gestión de Mascotas======");
                        Console.WriteLine("1. Registrar Mascota");
                        Console.WriteLine("2. Listar Mascotas");
                        Console.WriteLine("3. Editar Mascota");
                        Console.WriteLine("4. Eliminar Mascota");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("Elige una opcion: ");
                        string petOption = Console.ReadLine();
                        switch (petOption)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            case "5":
                                PetMenu = false;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Elige una opción válida (1/5)");
                                break;
                        }
                    }
                    break;
                case "3":
                    Console.Clear();
                    bool VetMenu = true;
                    while (VetMenu)
                    {
                        Console.WriteLine("======Gestión de Veterinarios======");
                        Console.WriteLine("1. Registrar Veterinario");
                        Console.WriteLine("2. Listar Veterinarios");
                        Console.WriteLine("3. Editar Veterinario");
                        Console.WriteLine("4. Eliminar Veterinario");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("Elige una opcion: ");
                        string VetOption = Console.ReadLine();
                        switch (VetOption)
                        {
                            case "1":
                                Vetflow.AddVet();
                                break;
                            case "2":
                                Vetflow.ListVets();
                                break;
                            case "3":
                                Vetflow.EditVet();
                                break;
                            case "4":
                                Vetflow.DeleteVet();
                                break;
                            case "5":
                                VetMenu = false;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Elige una opción válida (1/5)");
                                break;
                        }
                    }
                    break;
                case "4":
                    Console.Clear();
                    bool MedMenu = true;
                    while (MedMenu)
                    {
                        Console.WriteLine("======Gestión de Atenciones Médicas======");
                        Console.WriteLine("1. Registrar Atenciones Médica");
                        Console.WriteLine("2. Listar Atenciones Médicas");
                        Console.WriteLine("3. Editar Atenciones Médica");
                        Console.WriteLine("4. Eliminar Atenciones Médica");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("Elige una opcion: ");
                        string MedOption = Console.ReadLine();
                        switch (MedOption)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            case "5":
                                MedMenu = false;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Elige una opción válida (1/5)");
                                break;
                        }
                    }
                    break;
                case "5":
                    Console.Clear();
                    bool QueryMenu = true;
                    while (QueryMenu)
                    {
                        Console.WriteLine("======Consultas Avanzadas======");
                        Console.WriteLine("1. Consultar todas las mascotas de un cliente");
                        Console.WriteLine("2. Consultar el veterinario con más atenciones realizadas");
                        Console.WriteLine("3. Consultar la especie de mascota más atendida en la clínica");
                        Console.WriteLine("4. Consultar el cliente con más mascotas registradas");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("Elige una opcion: ");
                        string QueryOption = Console.ReadLine();
                        switch (QueryOption)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            case "5":
                                QueryMenu = false;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Elige una opción válida (1/5)");
                                break;
                        }
                    }
                    break;
                case "6":
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Elige una opción válida (1/6)");
                    break;
            }
        }
    }
}