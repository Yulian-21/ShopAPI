using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnApi.DataClasses
{
    public class Products
    {
        public const string CurrentFilePath = @"D:\Projects\WebApplication5\Data\Products.json";

        public string Name { get; set; }
        public int Id { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
