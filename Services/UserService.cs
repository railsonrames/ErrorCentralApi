using System;
using System.Collections.Generic;
using System.Linq;
using ErrorCentralApi.Models;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorCentralApi.Services
{
    public class UserService : IUserService
    {
        private readonly ErrorCentralDataContext _context;
        public UserService(ErrorCentralDataContext context)
        {
            this._context = context;
        }

        public User FindByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User FindById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        
        public User Save(User user)
        {
            user.Password = user.Password.Sha256();
            if (user.Id == null)
            {
                _context.Users.Add(user);
            }
            else
            {
                _context.Users.Update(user);
            }
            _context.SaveChanges();
            return user;
        }

         public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}