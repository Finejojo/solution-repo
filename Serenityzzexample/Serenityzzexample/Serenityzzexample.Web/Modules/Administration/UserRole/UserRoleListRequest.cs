using Serenity.Services;

namespace Serenityzzexample.Administration
{
    public class UserRoleListRequest : ServiceRequest
    {
        public int? UserID { get; set; }
    }
}