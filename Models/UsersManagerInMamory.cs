using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Data;

namespace WebPetAppShop.Models
{

    public class UsersManagerInMamory : IUsersManager
    {
        private readonly List<UserAccount> users = [];

        public UserAccount? TryGetByName(string name)
        {
            return this.users.FirstOrDefault(x => x.Name == name);
        }

        public List<UserAccount> GetAll()
        {
            return this.users;
        }

        public void Add(UserAccount user)
        {
            this.users.Add(user);
        }
    }
}
