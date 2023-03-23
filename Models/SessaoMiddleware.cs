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

        public override object Handle(object request, string email)
        {
            if (Sessao.EstaLogado(email)) {
                return _nextHandler.Handle(request, email);
            }
             throw new System.Exception("Usuario não está logado");
        }     
    }
    class UsuarioAdmin : Infra.AbstractHandler
    {
        private Controllers.Sessao Sessao;

        public UsuarioAdmin(Controllers.Sessao sessao)
        {
            Sessao = sessao;
        }

        public override object Handle(object request, string email)
        {
            if (Sessao.UsuarioPerfil(email, Perfil.ADMIN)) {
                _nextHandler.Handle(request, email);
            }
            
            throw new System.Exception("Opção invalida para o perfil");
        }     
    }

    class UsuarioUser : Infra.AbstractHandler
    {
        private Controllers.Sessao Sessao;

        public UsuarioUser(Controllers.Sessao sessao)
        {
            Sessao = sessao;
        }

        public override object Handle(object request, string email)
        {
            if (Sessao.UsuarioPerfil(email, Perfil.USER)) {
                _nextHandler.Handle(request, email);
            }
            return null;
        }     
    }
}