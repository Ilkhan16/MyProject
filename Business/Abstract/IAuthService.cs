using Core.Entities.Concrete;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Security.JWT;
using Entities.DTOs;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IResult UserExists(string email);
    IDataResult<AccessToken> CreateAccessToken(User user);
}