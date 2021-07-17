using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityCore
{


  public static  class ConvertData
    {


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
