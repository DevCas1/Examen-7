namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/Vector2\tVariable", order = 0)]
    public class Vector2Variable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public Vector2 Value;
        public bool ResetAtAwake;
        public Vector2 DefaultValue;
        
        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;

        public void SetValue(Vector2 value) => Value = value;

        public void SetValue(Vector2Variable value) => Value = value.Value;

        public void ApplyChange(Vector2 amount) => Value += amount;

        public void ApplyChange(Vector2Variable amount) => Value += amount.Value;
    }
}