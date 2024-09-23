using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning.Implementations
{
    internal static class ToFloatConverter
    {
        public static float ConvertToNumber<T>(object val)where T : class
        {
            if (val == null)
                return 0f;

            if (val is float)
                return (float)val;

            if (val is string)
            {
                if (float.TryParse((string)val, out float result))
                    return result;
            }

            throw new ArgumentException($"Cannot convert {val} to float.");
        }
    }
}
