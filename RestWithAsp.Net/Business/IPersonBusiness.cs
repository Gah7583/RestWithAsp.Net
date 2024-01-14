using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Hypermedia.Utils;

namespace RestWithAsp.Net.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PageSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO FindById(int id);
        PersonVO Disable (int id);
        void Delete(int id);

    }
}
