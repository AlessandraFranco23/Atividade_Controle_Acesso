using Infra;

namespace Models
{
    class UsuarioEstaLogado : Infra.AbstractHandler
    {
        private Controllers.Sessao Sessao;

        public UsuarioEstaLogado(Controllers.Sessao sessao)
        {
            Sessao = sessao;
        }

        public void Handle(object request, string email)
        {
            if (Sessao.EstaLogado(email)) {
                base.Handle(request, email);
            }
        }     
    }
    class UsuarioAdmin : Infra.AbstractHandler
    {
        private Controllers.Sessao Sessao;

        public UsuarioAdmin(Controllers.Sessao sessao)
        {
            Sessao = sessao;
        }

        public void Handle(object request, string email)
        {
            if (Sessao.UsuarioPerfil(email, Perfil.ADMIN)) {
                base.Handle(request, email);
            }
        }     
    }

    class UsuarioUser : Infra.AbstractHandler
    {
        private Controllers.Sessao Sessao;

        public UsuarioUser(Controllers.Sessao sessao)
        {
            Sessao = sessao;
        }

        public void Handle(object request, string email)
        {
            if (Sessao.UsuarioPerfil(email, Perfil.USER)) {
                base.Handle(request, email);
            }
        }     
    }
}