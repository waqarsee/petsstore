using WebApplication2.Model;

namespace WebApplication2.Services
{
    public interface IPetService
    {
       Task<List<Breed>> GetBreedsAsync();
    }
}
