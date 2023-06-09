using Models;

namespace Infra
{
    public interface IMiddleware
    {
        IMiddleware SetNext(IMiddleware handler);

        object Handle(object request, string email);
    }

    public abstract class AbstractHandler : IMiddleware
    {
        protected IMiddleware _nextHandler;

        public IMiddleware SetNext(IMiddleware handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public abstract object Handle(object request, string email);
        // {
            // if (this._nextHandler != null)
            // {
            //     return this._nextHandler.Handle(request, email);
            // }
            // else
            // {
            //     return null;
            // }
        // }
    }

}