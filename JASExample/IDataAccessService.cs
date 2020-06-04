using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JASExample
{
    public interface IDataAccessService
    {
        Task<bool> SqlPostAsync(string conString, string procName, string jsonBody);
    }
}
