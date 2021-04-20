using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing
{
  public class FileRepository
  {
    public T ReadFromFile<T>(string path) where T : class
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(T));

        var results = xml.Deserialize(reader) as T;
        return results;
      }
      catch
      {
        return null;
      }
    }
    public bool WriteToFile<T>(string path, T items) where T : class
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(writer, items);
        return true;
      }
      catch
      {
        return false;
      }
      finally
      {

      }
    }
  }
}
