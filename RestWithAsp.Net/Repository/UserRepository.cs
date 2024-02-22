using RestWithAsp.Net.Model;
using RestWithAsp.Net.Model.Context;
using System.Security.Cryptography;
using System.Text;

namespace RestWithAsp.Net.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RestWithAspDotNetContext _context;

        public UserRepository(RestWithAspDotNetContext context)
        {
            _context = context;
        }

        public User? ValidateCredentials(Data.VO.UserVO user)
        {
            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User? ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public bool RevokeToken(string userName)
        {
            var user = ValidateCredentials(userName);
            if (user == null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        private static string ComputeHash(string input, HashAlgorithm hashAlgorithm)
        {
            byte[] hashedBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var item in hashedBytes)
            {
                sBuilder.Append(item.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public User? RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
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
