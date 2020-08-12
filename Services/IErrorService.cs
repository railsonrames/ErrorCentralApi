using System;
using System.Collections.Generic;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Services
{
    public interface IErrorService
    {
        IList<Error> GetAll();
        Error FindById(Guid id);
        IList<Error> FindByLevelType(LevelType type);
        IList<Error> FindByOrigin(string origin);
        IList<Error> FindByDescription(string description);
        IList<Error> FindByEnvironment(Models.Environment environment);
        Error Save(Error error);
        bool Delete(Error error);
        bool Archive(Error error);

    }
}