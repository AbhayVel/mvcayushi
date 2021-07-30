using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityCore
{
  public static  class LinqExtention
    {
        public static IEnumerable<R> OuterJoin<T, Y, R>(this IEnumerable<T> objLeftList, IEnumerable<Y> objRightList, Func<T, Y, bool> predicate, Func<T, Y, R> output)
        {

            foreach (var item in objLeftList)
            {
                int i = 0;
                foreach (var item2 in objRightList)
                {
                    if (predicate(item, item2))
                    {
                        i++;
                        yield return output(item, item2);
                    }
                }
                if (i == 0)
                {
                    i++;
                    yield return output(item, default(Y));
                }
            }

            foreach (var item2 in objRightList)
            {
                int i = 0;
                foreach (var item in objLeftList)
                {
                    if (predicate(item, item2))
                    {
                        i++;
                        //  yield return output(item, item2);
                    }
                }
                if (i == 0)
                {
                    i++;
                    yield return output(default(T), item2);
                }
            }

        }
        public static IEnumerable<R> LeftJoin<T, Y, R>(this IEnumerable<T> objLeftList, IEnumerable<Y> objRightList, Func<T, Y, bool> predicate, Func<T, Y, R> output)
        {

            foreach (var item in objLeftList)
            {
                int i = 0;
                foreach (var item2 in objRightList)
                {
                    if (predicate(item, item2))
                    {
                        i++;
                        yield return output(item, item2);
                    }
                }
                if (i == 0)
                {
                    i++;
                    yield return output(item, default(Y));
                }
            }
        }
        public static IEnumerable<R> RightJoin<T, Y, R>(this IEnumerable<T> objRightList, IEnumerable<Y> objLeftList, Func<T, Y, bool> predicate, Func<T, Y, R> output)
        {

            return LeftJoin(objRightList, objLeftList, predicate, output);
        }
        public static IEnumerable<R> CrossJoin<T, Y, R>(this IEnumerable<T> objLeftList, IEnumerable<Y> objRightList, Func<T, Y, R> output)
        {
            foreach (var item in objLeftList)
            {
                foreach (var item2 in objRightList)
                {

                    yield return output(item, item2);

                }
            }

        }

    }
}
