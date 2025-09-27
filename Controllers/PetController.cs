using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Controllers;

public abstract class PetController : Controller
{
    public static bool Add(Pet pet)
    {
        ClientConnection.Pets.Add(pet);
        ClientConnection.SaveChanges();
        return true;
    }
    
    public static List<Pet> GetAll()
    {
        return ClientConnection.Pets
            .Include(p => p.Client) 
            .ToList();
    }
    
    public static bool Check(int id)
    {
        {
            var pet = ClientConnection.Pets.Find(id);

            if (pet == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
    public static bool Edit(int Id, Pet pet)
    {
        var oldPet = ClientConnection.Pets.Find(Id);

        if (oldPet == null)
        {
            return false;
        }

        oldPet.Name = pet.Name;
        ClientConnection.SaveChanges();
        return true;
    }
    
    public static bool Delete(int Id)
    {
        var pet = ClientConnection.Pets.Find(Id);
        
        if (pet == null)
        {
            return false;
        }
        ClientConnection.Pets.Remove(pet);
        ClientConnection.SaveChanges();
        return true;
    }
}