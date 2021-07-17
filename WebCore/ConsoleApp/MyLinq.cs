using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
  public  static class MyLinq
    {
      public  static List<T> ToMyList<T>(this IEnumerable<T> lst)
        {
            List<T> lstResult = new List<T>();

            foreach (var val in lst)
            {
                lstResult.Add(val);
            }

            return lstResult;
        }

      public  static T[] ToMyArray<T>(this IEnumerable<T> lst)
        {
            List<T> lstResult = new List<T>();

            foreach (var val in lst)
            {
                lstResult.Add(val);
            }

            return lstResult.ToArray();
        }
        public static T Max<T, Y>(this IEnumerable<T> lst, MyFunc<T, Y> func) where Y : IComparable
        {
            T value = default(T);
            /// List<T> lstResult = new List<T>();
            // int j = 0;
            bool isFirst = true;
            foreach (var val in lst)
            {
                if (isFirst)
                {
                    value = val;
                    isFirst = false;
                }
                if (func(val).CompareTo(func(value)) >= 0)
                {
                    value = val;
                }


            }
            return value;
            //  return lstResult;
        }

        public static T Min<T,Y>(this IEnumerable<T> lst, MyFunc<T, Y> func) where Y : IComparable
        {
          //  Y value = default(Y);
             T value = default(T);
            /// List<T> lstResult = new List<T>();
            // int j = 0;
            bool isFirst = true;
            foreach (var val in lst)
            {
                if (isFirst)
                {
                    value = val;
                    isFirst = false;
                }
                if (func(val).CompareTo(func(value)) <=0)
                {
                    value = val;
                }


            }
            return value;
            //  return lstResult;
        }


        public static bool All<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            /// List<T> lstResult = new List<T>();
            // int j = 0;
            foreach (var val in lst)
            {
                if (!func(val))
                {
                    return false;
                };


            }

            return true;
        }

        public static bool Any<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            /// List<T> lstResult = new List<T>();
            // int j = 0;
          //  bool ismatch = false;
            foreach (var val in lst)
            {
                if (func(val))
                {
                   return true;
                };


            }

              return false;
        }


        public   static IEnumerable<T> Where<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            /// List<T> lstResult = new List<T>();
            // int j = 0;
            foreach (var val in lst)
            {
                if (func(val))   yield return val;
            }
        }

        public static T SingleOrDefault<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            T value = default(T);
            bool isFirst = true;
             
            foreach (var val in lst)
            {
                if (func(val))
                {
                    if (isFirst)
                    {                       
                        isFirst = false;
                        value = val;
                    }
                    else
                    {
                        throw new Exception("multiple values found");
                    }
                    // return value;
                }
            }

            return value;
        }

        public static T SingleOrDefault<T>(this IEnumerable<T> lst)
        {
            T value = default(T);
            bool isFirst = true;
            foreach (var val in lst)
            {

                if (isFirst)
                {
                    
                    isFirst = false;
                    value = val;
                }
                else
                {
                    throw new Exception("multiple values found");
                }
            }
            return value;
            
        }


        public static T Single<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            T value = default(T);
            bool isFirst = true;
            bool isMatch = false;
            foreach (var val in lst)
            {
                if (func(val))
                {
                    if (isFirst)
                    {
                        isMatch = true;
                        isFirst = false;
                        value = val;
                    } else
                    {
                        throw new Exception("multiple values found");
                    }
                   // return value;
                }
            }
            if (isMatch) return value;
            throw new Exception("No record found");
        }

        public static T Single<T>(this IEnumerable<T> lst)
        {
            T value = default(T);
            bool isFirst = true;
            bool isMatch = false;
            foreach (var val in lst)
            {
                 
                    if (isFirst)
                    {
                        isMatch = true;
                        isFirst = false;
                        value = val;
                    }
                    else
                    {
                        throw new Exception("multiple values found");
                    }
            }
            if (isMatch) return value;
            throw new Exception("No record found");
        }

        public static T First<T>(this IEnumerable<T> lst)
        {
            foreach (var val in lst)
            {
                return val;
            }
            throw new Exception("No record found");
        }

        public static T First<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            foreach (var val in lst)
            {
                if (func(val))
                {
                    return val;
                }
            }
            throw new Exception("No record found");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> lst)
        {
            T value = default(T);

            foreach (var val in lst)
            { 
                    return val;
            }
            return value;
        }
        public static T FirstOrDefault<T>(this IEnumerable<T> lst, MyFunc<T, bool> func)
        {
            T value = default(T);
           
            foreach (var val in lst)
            {
                if (func(val))
                {
                    return val;
                }
            }
              return value;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> first)
        {
            //In Actual Code C# has created internal Set Class.
            List<T> set = new List<T>();            
            foreach (var val in first)
            {                
                if (!set.Contains(val))
                {
                    set.Add(val);
                    yield return val;
                }
            }
        }

        public static IEnumerable<T> Distinct<T,Y>(this IEnumerable<T> first, MyFunc<T, Y> func)
        {
            //In Actual Code C# has created internal Set Class.
            List<Y> set = new List<Y>();
            Y v;
            foreach (var val in first)
            {
                v = func(val);
                if (!set.Contains(v))
                {
                    set.Add(v);
                    yield return val;
                }                
            }
        }


        public static IEnumerable<T> Concate<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            /// List<T> lstResult = new List<T>();
            // int j = 0;
            foreach (var val in first)
            {
                 yield return val;
            }

            foreach (var val in second)
            {
                yield return val;
            }

            //  return lstResult;
        }
    }
}
