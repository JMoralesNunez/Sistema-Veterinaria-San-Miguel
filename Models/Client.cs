namespace Veterinaria;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Pet> Pets { get; set; }
}
