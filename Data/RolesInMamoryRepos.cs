using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class RolesInMamoryRepos : IRolesRepos
    {
        private List<Role> roles = new List<Role>();

        public List<Role> GetAll()
        {
            return this.roles;
        }

        public Role? TryByName(string name)
        {
            return this.roles.FirstOrDefault(x => x.Name == name);
        }

        public void Add(Role role)
        {
            this.roles.Add(role);
        }

        public void Remove(string name)
        {
            this.roles.RemoveAll(x => x.Name == name);
        }
    }

}