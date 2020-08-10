using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ErrorCentralApi.Services
{
    public class ErrorService : IErrorService
    {
        private ErrorCentralDataContext _context;
        public ErrorService(ErrorCentralDataContext context)
        {
            this._context = context;
        }

         public IList<Error> GetAll()
        {
            return _context.Errors.ToList();
        }

        public Error FindById(Guid id)
        {
            return _context.Errors.Find(id);
        }

        public void Archive(Error error)
        {
            var err = _context.Errors.FirstOrDefault(e => e.Id == error.Id);
            if (err != null)
            {
                err.ArchiveRecord = true;
                _context.SaveChanges();
            }
        }

        public void Delete(Error error)
        {
            var err = _context.Errors.FirstOrDefault(e => e.Id == error.Id);
            if (err != null)
            {
                _context.Errors.Remove(err);
                _context.SaveChanges();
            }
        }

        public IList<Error> FindByCreatedDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<Error> FindByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public IList<Error> FindByEnvironment(string environment)
        {
            throw new NotImplementedException();
        }

        public IList<Error> FindByLevelType(string type)
        {
            return _context.Errors.Where(e => e.LevelType == type).ToList();
        }

       

        public Error Save(Error error)
        {
            var state = error.Id != null ? EntityState.Added : EntityState.Modified;
            _context.Entry(error).State = state;
            _context.SaveChanges();
            
            return error;
        }

        public void Unarchive(Error error)
        {
            throw new NotImplementedException();
        }
    }
}