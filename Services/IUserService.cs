using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Services
{
    public interface IUserService
    {
        User FindById(Guid id);
        User FindByEmail(string email);
        User Save(User user);
    }
}