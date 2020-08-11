using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Services
{
    public interface IErrorService
    {
        IList<Error> GetAll();
        Error FindById(Guid id);
        IList<Error> FindByLevelType(string type);
        IList<Error> FindByOrigin(string origin);
        IList<Error> FindByDescription(string description);
        Error Save(Error error);
        bool Delete(Error error);
        bool Archive(Error error);

    }
}