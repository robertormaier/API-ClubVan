using club.van.api.data.dto.UsuarioArguments;

namespace club.van.api.business.Interface
{
    public interface IUsuarioBusiness
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest adicionarUsuarioRequest);

        bool AutenticarUusuario(string email, string senha);

        string CalculaHash(string Senha);
    }
}
