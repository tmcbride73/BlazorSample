using MatBlazor;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSample.Repositories
{
    public class UserRepository
    {
        public static string BaseUrl = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/BlazorSample/";
        public string UserDataPath = BaseUrl + "UserData/MOCK_DATA.json";
        public string UserImagesPath = BaseUrl + "UserData/";

        public List<User> GetAllUsers()
        {
            var json = File.ReadAllText(UserDataPath);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            return userList;

        }

        public List<string> GetAllUserNames()
        {
            var json = File.ReadAllText(UserDataPath);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            var userIdList = new List<string>();
            return userIdList;
        }

        public User GetSingleUser(string userId)
        {
            var json = File.ReadAllText(UserDataPath);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();

            var desiredUser =
                from user in userList
                where user.UserId.ToUpper() == userId.ToUpper()
                select user;

            return desiredUser.FirstOrDefault();

        }

        public void CreateUser(User user)
        {
            var userList = GetAllUsers();
            if (IsUniqueUser(user.UserId))
            {
                userList.Add(user);
                var json = JsonConvert.SerializeObject(userList);
                File.WriteAllText(UserDataPath, json);
            }
        }

        public bool IsUniqueUser(string userId)
        {
            var userList = GetAllUsers();
            foreach (var user in userList)
            {
                if (userId.ToUpper() == user.UserId.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }

        public void UpdateUser(User user)
        {
            var userList = GetAllUsers();

            userList[userList.FindIndex(x => x.UserId == user.UserId)] = user;

            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(UserDataPath, json);
        }

        public void DeleteUser(string userId)
        {
            var userList = GetAllUsers();

            userList.RemoveAt(userList.FindIndex(x => x.UserId == userId));

            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(UserDataPath, json);
        }

        public async Task UploadUserImageAsync(IMatFileUploadEntry file, User user)
        {
            using (var stream = new MemoryStream())
            {
                await file.WriteToStreamAsync(stream);
                user.ImageBase64 = Convert.ToBase64String(stream.ToArray());
            }
            UpdateUser(user);
        }

        public async Task<string> FileUploadToBase64Async(IMatFileUploadEntry file)
        {
            string imageBase64;
            using (var stream = new MemoryStream())
            {

                await file.WriteToStreamAsync(stream);
                imageBase64 = Convert.ToBase64String(stream.ToArray());
            }
            return imageBase64;
        }

    }
}
