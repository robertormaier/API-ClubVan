using club.van.api.data;
using club.van.api.data.dto.UsuarioArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IUsuarioBusiness
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest adicionarUsuarioRequest);

        Usuario AutenticarUsuario(string email, string senha);

        AtualizarUsuarioResponse Update(AtualizarUsuarioRequest atualizarUsuarioRequest);

        void Delete(Guid id);

        List<Usuario> ObterTodos();

        Usuario FindByEmail(string email);

        //Metodo Interno
        string CalculaHash(string Senha);
    }
}
