using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class EnumerableExtensions
    {

        public static ResultList<T1> ToResultList<T1>(this IEnumerable<T1> data)
        {
            return new ResultList<T1>(data);
        }

        public static Result<T1> ToResult<T1>(this T1 data)
        {
            return new Result<T1> { Data = data };
        }
    }
}