using System.Collections.Generic;

namespace Simba
{
    public abstract partial class SingleInstanceMonoBehaviour
    {
        private static readonly HashSet<SingleInstanceMonoBehaviour> MonoBehaviours =
            new HashSet<SingleInstanceMonoBehaviour>();

        /// <summary>
        /// Find first instance of SingleInstanceMonoBehaviour's inheritor
        /// </summary>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>First instance or null</returns>
        public static T Find<T>() where T : SingleInstanceMonoBehaviour
        {
            foreach (var monoBehaviour in MonoBehaviours)
                if (monoBehaviour is T casted)
                    return casted;

            return null;
        }

        /// <summary>
        /// Find every SingleInstanceMonoBehaviour's inheritor type of T
        /// </summary>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>List of results, empty list if no results found</returns>
        public static List<T> FindAll<T>() where T : SingleInstanceMonoBehaviour
        {
            var list = new List<T>();

            foreach (var monoBehaviour in MonoBehaviours)
                if (monoBehaviour is T casted)
                    list.Add(casted);

            return list;
        }

        /// <summary>
        /// Find every SingleInstanceMonoBehaviour's inheritor type of T
        /// </summary>
        /// <param name="list">List to append results in</param>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>Count of results added to list</returns>
        public static int FindAll<T>(List<T> list) where T : SingleInstanceMonoBehaviour
        {
            var count = 0;

            foreach (var monoBehaviour in MonoBehaviours)
                if (monoBehaviour is T casted)
                {
                    list.Add(casted);
                    count += 1;
                }

            return count;
        }
    }
}