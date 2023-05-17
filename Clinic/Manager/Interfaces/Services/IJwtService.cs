
using Core.Domain;

namespace Manager.Interfaces.Services;

public interface IJwtService
{
    string GerarToken(Usuario usuario);
}
