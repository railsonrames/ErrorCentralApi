using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Services
{
    public interface IUserService
    {
        IList<User> GetAll();
        User FindById(Guid id);
        User FindByEmail(string email);
        User Save(User user);
        User Update(User user);
    }
}