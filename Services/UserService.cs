using System;
using System.Collections.Generic;
using System.Linq;
using ErrorCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorCentralApi.Services
{
    public class UserService : IUserService
    {
        private ErrorCentralDataContext _context;
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
            return _context.Users.Find(id);
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}