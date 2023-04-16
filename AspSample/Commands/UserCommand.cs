using CQRS.Pattern;

namespace Sample.Commands
{
    public class UserCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
