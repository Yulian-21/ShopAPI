using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using MyDataProducts = System.Collections.Generic.Dictionary<int, (string, string, string)>;

namespace MyOwnApi.Service
{
    public class ProductDataService : IDataService
    {
        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);
        }

        public dynamic GetItems(string content)
        {
            return JObject.Parse(content);
        }

        public string GetProduct(dynamic items, int parameter)
        {
            var data = new List<string>();
            //var data1 = new MyDataCategories();

            foreach (var item in items.Items)
            {
                data.Add(item);
            }

            var neededItem = data[parameter];
            // string item = items.Items.Where( == parameter);
            return neededItem;
        }

        public MyDataProducts GetProducts(dynamic items)
        {
            //var data = new List<string>();
            var data = new MyDataProducts();

            foreach (var item in items.Items)
            {
                data.Add(item.Id, (item.CategoryId, item.Name, item.Price));
            }

            return data;
        }
    }
}
