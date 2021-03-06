﻿using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IUsuarioDao
    {
        Usuario Obter(string email, string senha);

        Usuario Obter(Guid id);

        List<Usuario> ObterTodos();

        void Salvar(Usuario usuario);

        void Atualizar(Usuario usuario);

        bool Existe(string email);

        void Delete(Usuario usuario);

        Usuario FindByEmail(string email);
    }
}
