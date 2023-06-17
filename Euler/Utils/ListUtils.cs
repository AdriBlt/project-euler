// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System;
    using System.Collections.Generic;

    public static class ListUtils
    {
        public static T FindMin<T>(List<T> list, Func<T, int> evaluationFunction)
        {
            int minValue = int.MaxValue;
            T mainElement = default(T);

            foreach (T element in list)
            {
                int value = evaluationFunction(element);
                if (value < minValue)
                {
                    minValue = value;
                    mainElement = element;
                }
            }

            return mainElement;
        }
        
        public static T FindMax<T>(List<T> list, Func<T, int> evaluationFunction)
        {
            int maxValue = int.MinValue;
            T maxElement = default(T);

            foreach (T element in list)
            {
                int value = evaluationFunction(element);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxElement = element;
                }
            }

            return maxElement;
        }
    }
}
