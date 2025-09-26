using Veterinaria.Data;
namespace Veterinaria.Controllers;

public abstract class ClientController : Controller
{
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
    
    public static bool Check(int id)
    {
        {
            var user = ClientConnection.Clients.Find(id);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static bool Edit(int clientId, Client user)
    {
            var oldClient = ClientConnection.Clients.Find(clientId);

            if (oldClient == null)
            {
                return false;
            }

            oldClient.Name = user.Name;
            ClientConnection.SaveChanges();
            return true;
    }

    public static bool Delete(int clientId)
    {
        var user = ClientConnection.Clients.Find(clientId);
        
        if (user == null)
        {
            return false;
        }
        ClientConnection.Clients.Remove(user);
        ClientConnection.SaveChanges();
        return true;
    }
}