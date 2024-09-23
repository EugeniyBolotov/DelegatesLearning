using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning.Implementations
{
    internal static class NumericOperations
    {
        interface IFloatWrapper
        {
            float Value { get; }
        }
        class FloatWrapper : IFloatWrapper
        {
            public float Value { get; }
            public FloatWrapper(float value)
            {
                Value = value;
            }
        }

        public static T? GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) 
                throw new ArgumentNullException(nameof(collection));

            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            T? maxVal = null;
            var iterator = float.MinValue;

            foreach (T item in collection)
            {
                float itemNumber = convertToNumber(item);

                if (itemNumber > iterator)
                {
                    iterator = itemNumber;
                    maxVal = item;
                }
            }
            return maxVal;
        }
        private static float GetParameter<T>(T param) where T : class => param switch
        {
            IFloatWrapper wrapper => wrapper.Value,
            float fl => fl,
            _ => throw new ArgumentException("Unable to convert type")
        };



        public static void Run()
        {
            List<IFloatWrapper> list = new() { new FloatWrapper(1f), new FloatWrapper(4.55f), new FloatWrapper(44f), new FloatWrapper(12f), new FloatWrapper(-44f), new FloatWrapper(-5f), new FloatWrapper(-9f) };
            float retVal = list.GetMax<IFloatWrapper>(GetParameter).Value;
            Console.WriteLine("MAX VAL: " + retVal);
        }


    }
}
