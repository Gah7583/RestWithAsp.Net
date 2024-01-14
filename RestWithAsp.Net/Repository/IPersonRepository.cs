using RestWithAsp.Net.Model;
using RestWithAsp.Net.Repository.Generic;

namespace RestWithAsp.Net.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(int id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
