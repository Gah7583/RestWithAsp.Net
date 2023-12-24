using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
        bool Exists(long id);
    }
}
