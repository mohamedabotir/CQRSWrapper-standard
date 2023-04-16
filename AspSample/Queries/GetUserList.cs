using AspSample.Models;
using CQRS.Pattern;

namespace AspSample.Queries
{
    public class GetUserList : IQuery<UserDTO>
    {
        public int UserId { get; set; }

        public GetUserList(int userId)
        {
            UserId = userId;
        }
    }
}
