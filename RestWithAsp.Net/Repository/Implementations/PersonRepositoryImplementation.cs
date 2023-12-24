using RestWithAsp.Net.Data;
using RestWithAsp.Net.Model;
using System.Security.Cryptography;

namespace RestWithAsp.Net.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly RestWithAspDotNetContext _context;

        public PersonRepositoryImplementation(RestWithAspDotNetContext context) 
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(person => person.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = FindById(person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return person;
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(person => person.Id.Equals(id));
        }
    }
}
