using System;
using System.Collections.Generic;

namespace PurePhysicist.Extensions
{
    public static class ListExtensions
    {
        #region Private Fields

        private static Random Rng = new Random();

        #endregion Private Fields

        #region Public Methods

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion Public Methods
    }
}