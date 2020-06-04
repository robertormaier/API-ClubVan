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
        
        Usuario GetUserById(Guid id);

        ResetUsuarioResponse RedefinirSenhaUsuario(ResetUsuarioRequest resetUsuarioRequest);

        //Metodo Interno
        string CalculaHash(string Senha);

        string GerarSenha();

        void EnviarEmail(string senha, string email);
    }
}
