using ASPTest.Models;

namespace ASPTest.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();
        public Beer? Get(int id);
    }
}
