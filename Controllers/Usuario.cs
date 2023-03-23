using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    public class Usuario
    {
        private Context Context;

        public Usuario(Context context)
        {
            Context = context;
        }

        public void Criar(string nome, string email, string senha, Perfil perfil)
        {
            Models.Usuario usuario = new Models.Usuario(nome, email, senha, perfil);

            Context.Usuarios.Add(usuario);
            Context.SaveChanges();
        }

        public void Alterar(int id, string nome, string email, string senha, Perfil perfil)
        {
            Models.Usuario usuario = Context.Usuarios.Where(usuario => usuario.Id.Equals(id)).FirstOrDefault();
            if (usuario != null)
            {
                usuario.Nome = nome;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.Perfil = perfil;
                Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            Models.Usuario usuario = Context.Usuarios.Where(usuario => usuario.Id.Equals(id)).FirstOrDefault();
            if (usuario != null)
            {
                Context.Remove(usuario);
            }
        }

        public List<Models.Usuario> Listar()
        {
            return Context.Usuarios.ToList();
        }

        public int TotalPerfil(Perfil perfil)
        {
            return Context.Usuarios.Where(usuario => usuario.Perfil.Equals(perfil)).Count();
        }

        public int TotalSessoesAtivas() {
            return Context.Sessoes.Include(sessao => sessao.Usuario).Where(sessao => sessao.DataExpiracao == null).Count();
        }
        
        public int TotalSessoes() {
            return Context.Sessoes.Count();
        }

    }
}