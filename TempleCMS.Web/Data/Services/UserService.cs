using TempleCMS.Web.Models;

namespace TempleCMS.Web.Data.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserModel GetUserModel(string userId)
        {
            var userModel =  _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserModel
            {
                Name = u.FullName,
                UserName = u.UserName!,
                Photo = u.Image
            }).FirstOrDefault();
            
            return userModel!;
        }
    }
}