using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HYDRA
{
    public static class ListExtensions
    {
        public static T MinBy<T>(this IEnumerable<T> elements, Func<T, float> FN, [CallerMemberName] string caller = null)
        {
            if (elements == null || !elements.Any())
                return default;

            var first = elements.First();
            var min = (first, FN(first));

            foreach (var element in elements)
            {
                var value = FN(element);
                if (value < min.Item2)
                    min = (element, value);
            }
            return min.Item1;
        }
    }
}