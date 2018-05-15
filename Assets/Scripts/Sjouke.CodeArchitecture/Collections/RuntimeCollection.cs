namespace Sjouke.CodeArchitecture.RuntimeCollections
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>[CreateAssetMenu(menuName = "Runtime Collections/{YourType}\tCollection")]</summary>
    public abstract class RuntimeCollection<T> : ScriptableObject 
    {
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item)) Items.Add(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item)) Items.Remove(item);
        }
    }
}