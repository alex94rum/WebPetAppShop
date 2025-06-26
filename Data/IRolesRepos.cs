using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IRolesRepos
    {
        // получение всех ролей
        public List<Role>? GetAll();

        // получения роли по имени
        Role? TryByName(string name);

        // добавление новой роли
        void Add(Role role);

        // обновление роли
        void Remove(string name);
    }

}