using AspSample.Models;
using CQRS.Pattern;
using Sample.Commands;

namespace AspSample.Queries
{
    public class GetUserListHandler : IQueryHandler<GetUserList, UserDTO>
    {
        public static List<UserCommand> _users = new List<UserCommand>{
        new UserCommand{Id=1,Name="mohamed"},
        new UserCommand{Id=2,Name="Ali"},
        new UserCommand{Id=3,Name="Omar"}
        };

        public Task<UserDTO> Handle(GetUserList query)
        {
            var result = _users.FirstOrDefault(e => e.Id == query.UserId);

            return Task.FromResult(new UserDTO { Id = result.Id, Name = result.Name });
        }
    }
}
