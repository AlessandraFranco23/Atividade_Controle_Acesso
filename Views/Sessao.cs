using System;
using Infra;

namespace Views
{
    public class Sessao: AbstractHandler
    {
        Controllers.Sessao Controller;

        public Sessao(Controllers.Sessao controller)
        {
            Controller = controller;
        }

        public String Logar()
        {
            Console.WriteLine("Informe o email");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a senha do usuario");
            string senha = Console.ReadLine();

            Controller.Login(email, senha);
            return email;
        }

        public void Logout()
        {
            Console.WriteLine("Informe o email");
            string email = Console.ReadLine();

            Controller.Logout(email);
        }

        
        public override object Handle(object request, string email)
        {

            if (request.ToString().Equals("Logar")) {
                return Logar();
            }

            if (request.ToString().Equals("Logout")) {
                Logout();
            }

            throw new Exception("Opcão invalida");
        }
    }
}