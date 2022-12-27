using API.Entities;

namespace API.Interfaces
{
    public interface ITokenservices
    {
        string CreateToken(AppUserClass user);
    }

}