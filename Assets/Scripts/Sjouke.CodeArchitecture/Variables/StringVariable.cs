namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/String\tVariable", order = 0)]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public string Value;
        public bool ResetAtAwake;
        public string DefaultValue;

        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;
        
        public void SetValue(string value) => Value = value;

        public void SetValue(StringVariable value) => Value = value.Value;

        public void ApplyChange(string amount) => Value += amount;

        public void ApplyChange(StringVariable amount) => Value += amount.Value;
    }
}