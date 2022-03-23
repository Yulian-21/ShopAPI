using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

//System.Collections.Generic.Dictionary<int, string>;
//using MyDataProducts = System.Collections.Generic.Dictionary<int, (string, string)>;

namespace MyOwnApi.Service
{
    public class DataService : IDataService
    {
        
        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);

        }
       
        public dynamic GetItems(string content)
        {
            content.GetType();
            return JObject.Parse(content);
        }
    }
}
