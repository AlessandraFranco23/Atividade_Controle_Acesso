using System;
using Microsoft.EntityFrameworkCore;

namespace Atividade
{
    public class Program
    {

        public static void Main(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseMySql("Server=localhost:3306;Database=Controle;Uid=root;Pwd=root;");
            
            Models.Context context = new Models.Context();

            Controllers.Usuario usuarioController = new Controllers.Usuario(context);
            Controllers.Sessao sessaoController = new Controllers.Sessao(context);

            Views.Sessao sessaoView = new Views.Sessao(sessaoController);
            Views.Usuario usuarioView = new Views.Usuario(usuarioController);

            Infra.IMiddleware usuarioEstaLogado = new Models.UsuarioEstaLogado(sessaoController);
            Infra.IMiddleware usuarioAdmin = new Models.UsuarioAdmin(sessaoController);
            Infra.IMiddleware usuarioUser = new Models.UsuarioUser(sessaoController);

            string email = "";
            int opt = 0;
            do
            {
                Console.WriteLine("1 - Cadastrar Usuario");
                Console.WriteLine("2 - Alterar Usuario");
                Console.WriteLine("3 - Excluir Usuario");
                Console.WriteLine("4 - Listar Usuario");
                Console.WriteLine("5 - Logar");
                Console.WriteLine("6 - Logout");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        usuarioEstaLogado.SetNext(usuarioAdmin).SetNext(usuarioView).Handle("Criar", email);
                        break;
                    case 2:
                        usuarioEstaLogado.SetNext(usuarioAdmin).SetNext(usuarioView).Handle("Alterar", email);
                        break;
                    case 3:
                        usuarioEstaLogado.SetNext(usuarioAdmin).SetNext(usuarioView).Handle("Excluir", email);
                        break;
                    case 4:
                        usuarioView.Listar();
                        break;
                    case 5:
                        email = sessaoView.Logar();
                        break;
                    case 6:
                        sessaoView.Logout();
                        email = "";
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }
}