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
        IList<Error> FindByEnvironment(string environment);
        IList<Error> FindByCreatedDate(DateTime date);
        IList<Error> FindByDescription(string description);
        Error Save(Error error);
        void Delete(Error error);

        void Archive(Error error);
        void Unarchive(Error error);

    }
}