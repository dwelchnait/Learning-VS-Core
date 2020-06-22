using System;
using System.Collections.Generic;
using System.Text;

#region Additinal Namespaces
using System.IO;
using System.Linq;
using System.Text.Json;
#endregion

namespace ConsoleApp
{
    public class JsonUtils
    {
        public IEnumerable<T> ReadData<T>(string fileName)
        {
            var result = new List<T>();
            string jsonText = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            result = JsonSerializer.Deserialize<List<T>>(jsonText, options);
            return result;
        }
    }
}
