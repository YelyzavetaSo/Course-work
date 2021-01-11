using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DAL
{
    public static class EntityContext<T>
    {
        //read from file
        public static List<T> ReadFile(string fname)
        {
            using (FileStream file = new FileStream(fname, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<T> deserialized = new List<T>();
                try
                {
                    deserialized = (List<T>)formatter.Deserialize(file);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return deserialized;
            }
        }

        //add in file
        public static void WriteInFile(string fname, T data)
        {
            using (FileStream file = new FileStream(fname, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<T> temp = new List<T>();
                if (file.Length != 0)
                {
                    temp = (List<T>)formatter.Deserialize(file);
                    file.SetLength(0);
                }
                temp.Add(data);
                try
                {
                    formatter.Serialize(file, temp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //clear file
        public static void ClearFile(string fmane)
        {
            using (FileStream file = new FileStream(fmane, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.SetLength(0);
            }
        }
    }

}
