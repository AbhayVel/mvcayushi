using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UtilityCore
{
    public class Binders
    {



        //public static dynamic ConvertData(string value, Type type)
        //{
           
        //    return Convert.ChangeType(value, type);
        //}


        public static T MyModelBinder<T>(T obj, HttpRequest request, string prefix="")
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            foreach (var item in request.Query)
            {
                if (d.ContainsKey(item.Key.ToLower()))
                {
                    d[item.Key.ToLower()] = item.Value;
                }
                else
                {
                    d.Add(item.Key.ToLower(), item.Value);
                }
            }

            foreach (var item in request.Form)
            {
                if (d.ContainsKey(item.Key.ToLower()))
                {
                    d[item.Key.ToLower()] =item.Value;
                } else
                {
                    d.Add(item.Key.ToLower(), item.Value);
                }
               
            }


            if (string.IsNullOrEmpty(prefix))
            {
                return MyModelBinder(obj, d, false);
            }
           else
            {
                return MyModelBinder(obj, d, prefix);
            }
        }

        public static T MyModelBinder<T>(T obj, Dictionary<string, string> d, string prefix = "")
        {
            return MyModelBinder(obj, d, prefix, false);
        }
            public static T MyModelBinder<T>(T obj, Dictionary<string, string> d, string prefix="", bool isDefaultAll = false)
        {
            //var arr = new string[d.Keys.Count];
            //d.Keys.CopyTo(arr, 0);

            string[] arr;
            if (!isDefaultAll)
            {
                arr = d.Where(x => !string.IsNullOrWhiteSpace(x.Value)).Select(X => X.Key).ToArray();
            }
            else
            {
                arr = d.Select(X => X.Key).ToArray();
            }
            var list = new List<string>();
            Dictionary<string, string> dobj = new Dictionary<string, string>();
            foreach (var it in arr)
            {
                if (it.StartsWith(prefix.ToLower()))
                {
                    list.Add(it);
                }
            }
            var length = (prefix.ToLower() + ".").Length;
            foreach (var ite in list)
            {
                dobj[ite.Substring(length).ToString()] = d[ite];
            }
            return MyModelBinder(obj, dobj, isDefaultAll);
        }

        public static T MyModelBinder<T>(T obj, Dictionary<string, string> d, bool isDefaultAll=false)
        {
            Type type = obj.GetType();
            string[] arr;
            if (!isDefaultAll)
            {
                arr = d.Where(x => !string.IsNullOrWhiteSpace(x.Value)).Select(X => X.Key).ToArray();
            } else
            {
                arr = d.Select(X => X.Key).ToArray();
            }
            
         //   d.Keys.CopyTo(arr,0);
            var propInfoArray = type.GetProperties();

            foreach (PropertyInfo item in propInfoArray)
            {

                if (item.PropertyType.IsClass  && !item.PropertyType.ToString().Equals( "System.String"))
                {
                    var str = arr.FirstOrDefault(x => x.StartsWith(item.Name.ToLower() + "."));
                    if (str != null)
                    {
                        dynamic refObj = item.PropertyType.Assembly.CreateInstance(item.PropertyType.FullName);
                        MyModelBinder(refObj, d, item.Name.ToLower());
                        item.SetValue(obj, refObj);
                    }
                }
                else
                {
                    if (d.ContainsKey(item.Name.ToLower()))
                    {
                        if (item.PropertyType.ToString().Equals("System.String"))
                        {
                            var value = d[item.Name.ToLower()];
                            item.SetValue(obj, value);
                        }
                        else
                        {
                            var value = d[item.Name.ToLower()].ConvertsData(item.PropertyType.ToString());
                            item.SetValue(obj, value);
                        }
                       
                    }
                }
                
            }
            return obj;
        }

    }
}
