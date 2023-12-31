﻿using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public bool Add(User model, UserAdress modelAdress, UserLogin modelLogin);
        public User GetById(int id);
        public User GetUser(UserLogin model);
    }
}
