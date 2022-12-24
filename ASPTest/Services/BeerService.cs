using ASPTest.Models;

namespace ASPTest.Services
{
    public class BeerService : IBeerService
    {

        private List<Beer> _beers=new List<Beer>()
        {
            new Beer(){Id=1,Name="Corona", Brand="Model"},
            new Beer(){Id=2, Name="Pukantus", Brand="Erdinger"}
        };

        public IEnumerable<Beer> Get() => _beers;

        public Beer? Get(int id) => _beers.FirstOrDefault(x=> x.Id==id);
    }
}
