using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
namespace Controllers
{
    public class Sessao
    {
        private Context Context;

        public Sessao(Context context)
        {
            Context = context;
        }

        public void Login(string email, string senha)
        {
            Models.Usuario usuario = Context.Usuarios.Where(usuariodb => usuariodb.Email == email).FirstOrDefault();

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            if (usuario.Senha != senha)
                throw new Exception("Senha invalida");

            Models.Sessao sessao = new Models.Sessao(usuario, "", DateTime.Now);
            Context.Sessoes.Add(sessao);

            Context.SaveChanges();

        }

        public void Logout(string email)
        {
            Models.Sessao sessao = Context.Sessoes.Include(sessao => sessao.Usuario)
                                                  .Where(sessao => sessao.Usuario.Email == email)
                                                  .FirstOrDefault();

            if (sessao == null)
                throw new Exception("Usuario não está logado");

            sessao.DataExpiracao = DateTime.Now;
            Context.SaveChanges();
        }

        public bool UsuarioPerfil(string email, Perfil perfil)
        {
            Models.Usuario usuario = Context.Sessoes.Include(sessao => sessao.Usuario)
                                                    .Where(sessao => sessao.Usuario.Email == email)
                                                    .Select(sessao => sessao.Usuario)
                                                    .FirstOrDefault();
            return perfil.Equals(usuario.Perfil);
        }

        public bool EstaLogado(string email)
        {
            Models.Sessao sessao = Context.Sessoes.Include(sessao => sessao.Usuario)
                                                  .Where(sessao => sessao.Usuario.Email == email && sessao.DataExpiracao == null)
                                                  .FirstOrDefault();
            return sessao != null;
        }

    }
}