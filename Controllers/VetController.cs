namespace Veterinaria.Controllers;

public abstract class VetController : Controller
{
    public static bool Add(Veterinarian user)
    {
        ClientConnection.Veterinarians.Add(user);
        ClientConnection.SaveChanges();
        return true;
    }
    
    public static List<Veterinarian> GetAll()
    {
        return ClientConnection.Veterinarians.ToList();
    }
    
    public static bool Check(int id)
    {
        {
            var user = ClientConnection.Veterinarians.Find(id);

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
    
    public static bool Edit(int Id, Veterinarian user)
    {
        var oldClient = ClientConnection.Veterinarians.Find(Id);

        if (oldClient == null)
        {
            return false;
        }

        oldClient.Name = user.Name;
        ClientConnection.SaveChanges();
        return true;
    }
    
    public static bool Delete(int Id)
    {
        var user = ClientConnection.Veterinarians.Find(Id);
        
        if (user == null)
        {
            return false;
        }
        ClientConnection.Veterinarians.Remove(user);
        ClientConnection.SaveChanges();
        return true;
    }
}