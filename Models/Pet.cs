namespace Veterinaria;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public MedicalHistory History { get; set; }
    
    public int ClientId { get; set; }
    
    public Client Client { get; set; }
    
    public ICollection<Veterinarian> Veterinarians { get; set; }
}