namespace Views
{
    public class Sessao
    {
        Controllers.Sessao Controller;

        public Sessao(Controllers.Sessao controller)
        {
            Controller = controller;
        }

        public void Logar()
        {
            Console.WriteLine("Informe o email");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a senha do usuario");
            string senha = Console.ReadLine();

            Controller.Login(email, senha);
        }

        public void Logout()
        {
            Console.WriteLine("Informe o email");
            string email = Console.ReadLine();

            Controller.Logout(email);
        }
    }
}