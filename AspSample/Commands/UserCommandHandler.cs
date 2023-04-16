using CQRS.Pattern;

namespace Sample.Commands
{
    public class UserCommandHandler : ICommandHandler<UserCommand>
    {
        public Task Handle(UserCommand userCommand)
        {
            Console.WriteLine($"Store Handled Id: {userCommand.Id} ,Name:{userCommand.Name}");
            return Task.FromResult("Handled");
        }
    }
}
