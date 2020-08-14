using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;
using System.Linq;

namespace ErrorCentralApi.Services
{
    public class ErrorService : IErrorService
    {
        private readonly ErrorCentralDataContext _context;
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
            return _context.Errors.FirstOrDefault(e => e.Id == id);
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
            if(error != null)
            {
                _context.Errors.Remove(err);
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

        public IList<Error> FindByLevelType(LevelType type)
        {
            return _context.Errors.Where(e => e.LevelType == type).ToList();
        }

        public IList<Error> FindByEnvironment(Models.Environment environment)
        {
            var result = _context.Errors.Where(e => e.Environment == environment).ToList();
            return result;
        }

        public IList<Error> FindByEnvironment(string environment, string orderBy)
        {
            return _context.Errors
                .Where(e => e.Environment.ToString() == environment)
                .OrderBy(e => e.LevelType)
                .ToList();
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

        // private int Frequency(string levelType)
        // {
        //     return _context.Errors
        //         .Where(e => e.LevelType.ToString() == levelType)
        //         .GroupBy(e => e.LevelType)
        //         .Count();
        // }

    }
}