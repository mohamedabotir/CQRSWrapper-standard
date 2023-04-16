using AspSample.Models;
using CqrsInvolve.Pattern;

namespace AspSample.Queries
{
    public class GetUserList:IQuery<UserDTO>
    {
        public int UserId { get; set; }

        public GetUserList(int userId)
        {
            UserId = userId;
        }
    }
}
