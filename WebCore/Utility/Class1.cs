using System;
using System.Collections.Generic;
using System.Reflection;

namespace Utility
{
    public class Binders
    {



        public static dynamic ConvertData(string value, Type type)
        {

            return Convert.ChangeType(value, type);
        }


        public static T MyModelBinder<T>(T obj, Dictionary<string, string> d)
        {
            Type type = obj.GetType();

            var propInfoArray = type.GetProperties();

            foreach (PropertyInfo item in propInfoArray)
            {
                if (d.ContainsKey(item.Name))
                {

                    //  item.SetValue(obj, "1");
                    Object value = ConvertData(d[item.Name], Type.GetType(item.PropertyType.ToString()));
                     item.SetValue(obj,value as Object );

                     


                }
            }
            return obj;
        }

    }
}
