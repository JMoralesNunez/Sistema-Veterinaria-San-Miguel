namespace Veterinaria;

public class MedicalHistory
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public int PetId { get; set; }
    public Pet Pet { get; set; }
}