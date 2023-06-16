using CQRS.Pattern;
using Sample.Commands;
using System;

namespace AspSample.Commands
{
    public class JobCommadHandler : ICommandHandler<JobIdCommand>
    {
        public int Fail { get; set; }
        public Task Handle(JobIdCommand command)
        {
            if(command .IsFail== true)
            throw new Exception("Db Exception Test Retries");

            Console.WriteLine($"Store Handled JobId: {command.JobId} ,JobName:{command.JobName}");
            return Task.FromResult("Handled");
        }
    }
}
