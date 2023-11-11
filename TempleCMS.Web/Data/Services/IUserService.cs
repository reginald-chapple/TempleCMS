using TempleCMS.Web.Models;

namespace TempleCMS.Web.Data.Services
{
    public interface IUserService
    {
        UserModel GetUserModel(string userId);
    }
}