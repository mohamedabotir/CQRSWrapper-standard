using CQRS.Pattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRSWrapper.Decorator
{
    public sealed class DatabaseRetriesDecorator<TCommand> : ICommandHandler<TCommand>
     where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> handler;

        private int RetriesCount { set; get; } = 3;

        public int setRetriesCount { set {  RetriesCount = value; } }
        public DatabaseRetriesDecorator(ICommandHandler<TCommand> handler)
        {
            this.handler = handler;
        }
        public async Task Handle(TCommand command)
        {
           
                for (int i = 0; i < RetriesCount; i++)
                {
                try
                {
                    await handler.Handle(command);
                    return;

                }
                catch (Exception)
            {
                RetriesCount--;
                Console.WriteLine($"Retries Invoke Command");
                if (RetriesCount == 0)
                    throw;
            }
        

            }
            
        }
    }

}
