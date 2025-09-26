using Veterinaria.Data;
namespace Veterinaria.Controllers;

public abstract class ClientController
{
    private static readonly Db ClientConnection = new Db();
    
    public static bool Add(Client user)
    {
        ClientConnection.Clients.Add(user);
        ClientConnection.SaveChanges();
        return true;
    }
    
    public static List<Client> GetAll()
    {
        return ClientConnection.Clients.ToList();
    }
}