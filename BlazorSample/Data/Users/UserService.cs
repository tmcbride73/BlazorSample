using BlazorSample.Repositories;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSample.Data
{
    public class UserService
    {
        [Inject]
        protected IMatToaster Toaster { get; set; }

        public Task<List<User>> GetUsersAsync()
        {
            var userRepo = new UserRepository();
            var userList = userRepo.GetAllUsers();

            return Task.FromResult(userList);
        }

        public User GetSingleUser(string userId)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetSingleUser(userId);

            return user;
        }


        public List<string> GetAllUserNames()
        {
            var userRepo = new UserRepository();
            var userIdList = userRepo.GetAllUserNames();
            return userIdList;
        }

        public void CreateNewUser(User user)
        {
            var userRepo = new UserRepository();
            userRepo.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            var userRepo = new UserRepository();
            userRepo.UpdateUser(user);
        }

        public void DeleteUser (User user)
        {
            var userRepo = new UserRepository();
            userRepo.DeleteUser(user.UserId);
        }

        public Task<string> FileUploadToBase64Async(IMatFileUploadEntry file)
        {
            var userRepo = new UserRepository();
            var imageBase64 = userRepo.FileUploadToBase64Async(file);
            return imageBase64;
        }
    }
}
