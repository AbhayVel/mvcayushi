using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace UtilityCore
{


  public static  class ConvertData
    {

        public static byte[] ObjectToByteArray<T>(T obj) where T : class
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static T ByteArrayToObject<T>(byte[] arrBytes)  where T: class
        {
            if (arrBytes == null)
            {
                return null;
            }
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj =  binForm.Deserialize(memStream) as T;
            return obj;
        }


        public   static dynamic GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }

     public   static dynamic ConvertsData(this string str, string type)
        {
            Type ty = Type.GetType(type);
            try
            {
                Type t = Nullable.GetUnderlyingType(ty) ?? ty;

                return Convert.ChangeType(str, t);
            }

            catch (Exception ex)
            {

                return GetDefaultValue(ty);
            }
        }
        public   static dynamic Converts<T>(this string val)
        {
            try
            {
                return Convert.ChangeType(val, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
