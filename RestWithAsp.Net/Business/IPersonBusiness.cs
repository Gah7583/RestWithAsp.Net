using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
    }
}
