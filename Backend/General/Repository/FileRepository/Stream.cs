// File:    Stream.cs
// Author:  Vlajkov
// Created: Wednesday, May 27, 2020 10:29:03 PM
// Purpose: Definition of Class Stream

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{

    public class Stream<T> : IStream<T>
   {
        private string path;
   
        public Stream(string path)
        {
            this.path = path;
        }

        public IEnumerable<T> GetAll()
        {
            string jsonString = File.Exists(path) ? File.ReadAllText(path) : "";
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            if (!string.IsNullOrEmpty(jsonString))
            {
                return JsonConvert.DeserializeObject<List<T>>(jsonString, settings);
            } else
            {
                return new List<T>();
            }
        }

        public void SaveAll(IEnumerable<T> entities)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.All;
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter writer = new StreamWriter(path)) 
                using(JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, entities);
                }
        }
    }
}