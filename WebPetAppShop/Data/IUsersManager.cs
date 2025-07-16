using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount? TryGetByName(string name);
        void ChangePassword(string userName, string newPassword);
    }
}
