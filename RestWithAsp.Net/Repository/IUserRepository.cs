using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
