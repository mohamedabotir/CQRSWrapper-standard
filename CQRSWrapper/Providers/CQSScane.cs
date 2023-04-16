using CQRS.Pattern;
using System;
using System.Threading.Tasks;

namespace CQRS.Providers
{
    public class CQSScane
    {
        private IServiceProvider _service;


        public CQSScane(IServiceProvider service)
        {


            _service = service;

        }


        public void Dispatch(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            Type[] args = { command.GetType() };
            Type handlerType = type.MakeGenericType(args);
            dynamic handler = _service.GetService(handlerType);
            dynamic result = handler.Handle((dynamic)command);

        }

        public async Task<T> Dispatch<T>(IQuery<T> query)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] args = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(args);
            dynamic handler = _service.GetService(handlerType);
            dynamic result = await handler.Handle((dynamic)query);
            return (T)result;
        }


    }
}
