using Serenity.Services;
using MyRequest = Serenityzzexample.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<Serenityzzexample.Administration.UserRow>;
using MyRow = Serenityzzexample.Administration.UserRow;

namespace Serenityzzexample.Administration
{
    public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
    {
        public UserListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}