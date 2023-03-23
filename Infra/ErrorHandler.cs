using System;

namespace Infra
{
    public class ErrorHandler : AbstractHandler
    {
        public override object Handle(object request, string email)
        {
            try
            {
                _nextHandler.Handle(request, email);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            return null;
        }
    }
}