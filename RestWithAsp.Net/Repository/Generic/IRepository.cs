using RestWithAsp.Net.Model.Base;

namespace RestWithAsp.Net.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(int id);
    }
}
