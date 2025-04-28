using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HYDRA
{
    public static class ListExtensions
    {
        public static T MinBy<T>(this List<T> elements, Func<T, float> FN, [CallerMemberName] string caller = null)
        {
            if (elements == null || !elements.Any())
                throw new PreconditionException($"{nameof(elements)} is empty or null \n {caller} -> {nameof(MinBy)}");

            var min = (elements[0], FN(elements[0]));

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