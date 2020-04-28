using BlazorSample.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorSample.Infrastructure
{
    public class UserRepository
    {
        public UserRepository(string jsonLocation)
        {
            BaseUrl = jsonLocation;
            UserDataPath = BaseUrl + "UserData/MOCK_DATA.json";
            UserImagesPath = BaseUrl + "UserData/";
        }

        public string BaseUrl { get; set; }
        public string UserDataPath { get; set; }
        public string UserImagesPath { get; set; }

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
    }
}
