using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using MyOwnApi.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MyDataCategories =
    System.ValueTuple<int, string>;

namespace MyOwnApi
{
    public class Categories
    {

        public const string CategoriesFilePath = @"D:\Projects\MyOwnApi\Data\Categories.json"; 
        public DataService CategoryDataService = new();

        public int Id { get; set; }

        public string Name { get; set; }

        public string GetCategoryById(int parameter)
        {
            var items = GetData();
            var data = new List<MyDataCategories>();
            string returnedData = "";

            foreach (var item in items.items)
            {
                if (Convert.ToInt32(item.Id) == parameter)
                 returnedData = item.Name;
                    break;
            }

            return returnedData;
        }

        public int GetIdByCategory(string category)
        {
            var items = GetData();
            int returnedData = 0;

            foreach (var item in items.items)
            {
                if (item.Name == category)
                {
                    returnedData = item.Id;
                    break;
                }
                   
            }

            return returnedData;
        }

        public List<string> GetCategories()
        {
            var items = GetData();
            var data = new List<MyDataCategories>();

            foreach (var item in items.Items)
            {
                MyDataCategories temp = (Convert.ToInt32(item.Id), item.Name);
                data.Add(temp);
            }

            var list = new List<string>();
            foreach (var item in data)
            {
                list.Add(item.Item2);
            }

            return list;
        }

        public List<string> GetCategoriesPost(string parol) //[FromBody]
        {
            var authorizationString = "asd123";
            if (authorizationString == parol)
            {
                var items = GetData();
                var data = new List<MyDataCategories>();

                foreach (var item in items.items)
                {
                    MyDataCategories temp = (Convert.ToInt32(item.Id), item.Name);
                    data.Add(temp);
                }

                var list = new List<string>();
                foreach (var item in data)
                {
                    list.Add(item.Item2);
                }

                return list;
            }
            else return null;
             
        }

        //public void PutById(Categories value)
        //{
        //    var converted = JObject.Parse(items);
        //    var result = JsonConvert.SerializeObject(CategoriesFilePath, converted);
        //    //var list = JsonConvert.DeserializeObject<List<Categories>>(CategoriesFilePath);
        //    //list.Add(value);
        //    //var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
        //}

        public dynamic GetData()
        {
            var content = CategoryDataService.GetFileContent(CategoriesFilePath);
            var items = CategoryDataService.GetItems(content);
            return items;
        }



    }
}
