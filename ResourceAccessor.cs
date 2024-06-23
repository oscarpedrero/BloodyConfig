using BloodyConfig.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BloodyConfig
{
    public class ResourceAccessor
    {
        public string GetResourceString(string resourceName)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            return resourceManager.GetString(resourceName);
        }

        public T DeserializeJsonResource<T>(string resourceName)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            byte[] jsonBytes = GetResourceBytes(resourceName);
            if (jsonBytes == null)
            {
                throw new ArgumentException($"Resource '{resourceName}' not found.");
            }
            string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);
            Debug.WriteLine(jsonString);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public T DeserializeJsonFile<T>(string filename)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            Debug.WriteLine(filename);
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename));
        }

        public object GetResourceObject(string resourceName)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            return resourceManager.GetObject(resourceName);

        }
        public byte[] GetResourceBytes(string resourceName)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            return (byte[])resourceManager.GetObject(resourceName);
        }
    }
}
