namespace Sjouke.CodeArchitecture.Events
{
    using UnityEngine;
    using System.Collections.Generic;

    [CreateAssetMenu(menuName = "Events/Game\tEvent")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>The list of listeners that this event will notify if it is raised.</summary>
        private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int index = eventListeners.Count - 1; index >= 0; index--)
                eventListeners[index].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}