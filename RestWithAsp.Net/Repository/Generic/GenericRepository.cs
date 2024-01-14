using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Model.Base;
using RestWithAsp.Net.Model.Context;

namespace RestWithAsp.Net.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly RestWithAspDotNetContext _context;

        private readonly DbSet<T> dataset;

        public GenericRepository(RestWithAspDotNetContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            };
        }

        public void Delete(int id)
        {
            var result = FindByID(id);
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = query;
                result = command.ExecuteScalar().ToString();
            }
            return int.Parse(result);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result = FindByID(item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
