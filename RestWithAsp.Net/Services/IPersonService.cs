using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
    }
}
