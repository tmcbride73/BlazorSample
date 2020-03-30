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
        protected IMatToaster Toaster { get; set; }
        protected UserRepository _userRepo { get; set; }
        public UserService(UserRepository userRepo, IMatToaster toaster)
        {
            _userRepo = userRepo;
            Toaster = toaster;
        }


        public Task<List<User>> GetUsersAsync()
        {
            var userList = _userRepo.GetAllUsers();

            return Task.FromResult(userList);
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

        public Task<string> FileUploadToBase64Async(IMatFileUploadEntry file)
        {
            var imageBase64 = _userRepo.FileUploadToBase64Async(file);
            return imageBase64;
        }
    }
}
