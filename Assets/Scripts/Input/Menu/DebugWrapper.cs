public class DebugWrapper : UnityEngine.MonoBehaviour 
{
    public void Debug(string message) => UnityEngine.Debug.Log(message);
    public void DebugError(string message) => UnityEngine.Debug.LogError(message);
}