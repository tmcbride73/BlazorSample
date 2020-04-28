using BlazorSample.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSample.Domain;

namespace BlazorSample.Application
{
    public class UserService
    {
        protected UserRepository _userRepo { get; set; }
        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<List<User>> GetUsersAsync()
        {
            var userList = _userRepo.GetAllUsers();

            return Task.FromResult(userList);
        }

        public List<User> GetAllUsers()
        {
            var userList = _userRepo.GetAllUsers();
            return userList;
        }

        public User GetSingleUser(string userId)
        {
            var user = _userRepo.GetSingleUser(userId);

            return user;
        }


        public List<string> GetAllUserNames()
        {
            var userIdList = _userRepo.GetAllUserNames();
            return userIdList;
        }

        public void CreateNewUser(User user)
        {
            _userRepo.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepo.UpdateUser(user);
        }

        public void DeleteUser (User user)
        {
            _userRepo.DeleteUser(user.UserId);
        }
    }
}
