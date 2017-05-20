using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ratings.Web.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> LeftJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                     IEnumerable<TInner> inner,
                                                     Func<TSource, TKey> primaryKey,
                                                     Func<TInner, TKey> foreignKey,
                                                     Func<TSource, TInner, TResult> resultCollection)
        {
            var result = from s in source
                         join i in inner
                             on primaryKey(s) equals foreignKey(i) into joinData
                         from left in joinData.DefaultIfEmpty()
                         select resultCollection(s, left);

            return result;
        }
    }
}