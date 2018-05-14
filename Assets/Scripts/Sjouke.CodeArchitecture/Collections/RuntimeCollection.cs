namespace Sjouke.CodeArchitecture.RuntimeCollections
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>[CreateAssetMenu(menuName = "Runtime Collections/{YourType}\tCollection")]</summary>
    public abstract class RuntimeCollection<T> : ScriptableObject 
    {
        public List<T> Items = new List<T>();

        public void Add(T thing)
        {
            if (!Items.Contains(thing)) Items.Add(thing);
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing)) Items.Remove(thing);
        }
    }
}