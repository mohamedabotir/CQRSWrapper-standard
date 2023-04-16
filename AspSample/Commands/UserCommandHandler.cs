using Sample.Pattern;

namespace Sample.Commands
{
    public class UserCommandHandler : ICommandHandler<UserCommand>
    {
        public Task Handle(UserCommand userCommand)
        {
            Console.WriteLine($"Query Handled Id: {userCommand.Id} ,Name:{userCommand.Name}");
          return  Task.FromResult("Handled");
        }
    }
}
