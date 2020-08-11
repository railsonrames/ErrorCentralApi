using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;
using System.Linq;

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

        public bool Archive(Error error)
        {
            var err = _context.Errors.FirstOrDefault(e => e.Id == error.Id);
            if (err != null)
            {
                err.ArchiveRecord = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Error error)
        {
            var err = _context.Errors.FirstOrDefault(e => e.Id == error.Id);
            if (err != null)
            {
                _context.Errors.Remove(err);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(Guid id)
        {
            var error = _context.Errors.FirstOrDefault(e => e.Id == id);
            if(error != null)
            {
                _context.Errors.Remove(error);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<Error> FindByDescription(string description)
        {
            return _context.Errors.Where(e => e.Description == description).ToList();
        }

        public IList<Error> FindByOrigin(string origin)
        {
            return _context.Errors.Where(e => e.Origin == origin).ToList();
        }

        public IList<Error> FindByLevelType(string type)
        {
            return _context.Errors.Where(e => e.LevelType.ToString() == type).ToList();
        }

       

        public Error Save(Error error)
        {
            if (error.Id == null)
            {
                _context.Errors.Add(error);
            }
            else
            {
                _context.Errors.Update(error);
            }
            _context.SaveChanges();
            
            return error;
        }

    }
}