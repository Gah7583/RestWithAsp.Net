using Microsoft.IdentityModel.JsonWebTokens;
using RestWithAsp.Net.Configurations;
using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Repository;
using RestWithAsp.Net.Services;
using System.Security.Claims;

namespace RestWithAsp.Net.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly TokenConfiguration _configuration;

        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var acessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

           _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), acessToken, refreshToken);
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AcessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var user = _repository.ValidateCredentials(username);

            if (user == null || 
                refreshToken != user.RefreshToken || 
                user.RefreshTokenExpiryTime <= DateTime.Now) 
                return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true, 
                createDate.ToString(DATE_FORMAT), 
                expirationDate.ToString(DATE_FORMAT), 
                accessToken, 
                refreshToken);
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
