using Veterinaria.Data;
namespace Veterinaria.Controllers;

public abstract class Controller
{
    protected static readonly Db ClientConnection = new Db();
    public abstract bool Add();
    public abstract bool Check();
    public abstract bool Edit();
    public abstract bool Delete();
}