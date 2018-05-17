using Sjouke.CodeArchitecture.Events;
using UnityEngine;

public class EventOnStart : MonoBehaviour 
{
    public GameEvent Event;
    private void Start() => Event.Raise();
}