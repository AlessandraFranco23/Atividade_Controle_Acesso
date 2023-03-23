using Infra;
using System;

namespace Views
{
    public class Usuario: AbstractHandler
    {
        Controllers.Usuario Controller;

        public Usuario(Controllers.Usuario controller)
        {
            Controller = controller;
        }

        public void Criar()
        {
            Console.WriteLine("Digite o nome do usuario");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o email do usuario");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a senha do usuario");
            string senha = Console.ReadLine();

            Console.WriteLine("Perfil: [A]-Admin [U]-User");
            string perfilStr = Console.ReadLine();
            Models.Perfil perfil;
            if ("A".Equals(perfilStr))
            {
                perfil = Models.Perfil.ADMIN;
            }
            else
            {
                perfil = Models.Perfil.USER;
            }

            Controller.Criar(nome, email, senha, perfil);
        }

        public void Alterar()
        {
            Console.WriteLine("Informe o id:");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do usuario");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o email do usuario");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a senha do usuario");
            string senha = Console.ReadLine();

            Console.WriteLine("Perfil: [A]-Admin [U]-User");
            string perfilStr = Console.ReadLine();
            Models.Perfil perfil;
            if ("A".Equals(perfilStr))
            {
                perfil = Models.Perfil.ADMIN;
            }
            else
            {
                perfil = Models.Perfil.USER;
            }

            Controller.Alterar(id, nome, email, senha, perfil);
        }

        public void Excluir()
        {
            Console.WriteLine("Informe o id:");
            int id = Int32.Parse(Console.ReadLine());

            Controller.Excluir(id);
        }

        public void Listar() {
            Console.Write("Total Ativo:");
            Console.WriteLine(Controller.TotalSessoesAtivas());

            Console.Write("Total Admin:");
            Console.WriteLine(Controller.TotalPerfil(Models.Perfil.ADMIN));
            
            Console.Write("Total User:");
            Console.WriteLine(Controller.TotalPerfil(Models.Perfil.USER));

            Console.WriteLine("-------");

            foreach (Models.Usuario usuario in Controller.Listar())
            {
                Console.WriteLine("id:" + usuario.Id + " nome:" + usuario.Nome + " email:" + usuario.Email);
            }
        }

        
        public override object Handle(object request, String email)
        {
            if (request.ToString().Equals("Criar")) {
                Criar();
            }

            if (request.ToString().Equals("Alterar")) {
                Alterar();
            }

            if (request.ToString().Equals("Excluir")) {
                Excluir();
            }
        
            throw new Exception("Opcão invalida");
        }

    }
}