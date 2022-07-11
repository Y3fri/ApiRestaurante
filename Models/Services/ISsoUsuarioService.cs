
using Restaurant.Models.Request;
using Restaurant.Models.Response;

namespace Restaurant.Services
{
    public interface ISsoUsuarioService
    {
        UserResponse Auth(SsoUsuarioRequest usuario );
     }
}
