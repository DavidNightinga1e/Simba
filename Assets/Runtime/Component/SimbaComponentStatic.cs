using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simba
{
    public abstract partial class SimbaComponent
    {
        private static readonly Dictionary<Type, SimbaComponent> TypeToInstance
            = new Dictionary<Type, SimbaComponent>();

        private static void Add(SimbaComponent component)
        {
            var type = component.GetType();
            if (TypeToInstance.ContainsKey(type))
                Debug.LogError($"{type} was already instantiated somewhere");
            else
                TypeToInstance.Add(type, component);
        }

        private static void Remove(SimbaComponent component)
        {
            var type = component.GetType();
            if (TypeToInstance.ContainsKey(type))
                TypeToInstance.Remove(type);
            else
                throw new ApplicationException($"{component} was not cached");
        }

        /// <summary>
        /// Get SimbaComponent's inheritor instance 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : SimbaComponent
        {
            var type = typeof(T);

            if (TypeToInstance.ContainsKey(type))
                return (T) TypeToInstance[type];

            Debug.LogError($"{type} was not cached (Maybe you are invoking Get() on Awake?)");
            return null;
        }

        /// <summary>
        /// Find first instance of SimbaComponent's inheritor
        /// </summary>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>First instance or null</returns>
        public static T Find<T>() where T : SimbaComponent
        {
            foreach (var monoBehaviour in TypeToInstance.Values)
                if (monoBehaviour is T casted)
                    return casted;

            return null;
        }

        /// <summary>
        /// Find every SimbaComponent's inheritor type of T
        /// </summary>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>List of results, empty list if no results found</returns>
        public static List<T> FindAll<T>() where T : SimbaComponent
        {
            var list = new List<T>();

            foreach (var monoBehaviour in TypeToInstance.Values)
                if (monoBehaviour is T casted)
                    list.Add(casted);

            return list;
        }

        /// <summary>
        /// Find every SimbaComponent's inheritor type of T
        /// </summary>
        /// <param name="list">List to append results in</param>
        /// <typeparam name="T">Inheritor type</typeparam>
        /// <returns>Count of results added to list</returns>
        public static int FindAll<T>(List<T> list) where T : SimbaComponent
        {
            var count = 0;

            foreach (var monoBehaviour in TypeToInstance.Values)
                if (monoBehaviour is T casted)
                {
                    list.Add(casted);
                    count += 1;
                }

            return count;
        }
    }
}