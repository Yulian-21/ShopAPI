using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnApi.Service
{
    public interface IDataService
    {
        public string GetFileContent(string path);

        public dynamic GetItems(string content);
    }
}
