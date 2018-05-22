namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/Int\tVariable", order = 0)]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public int Value;
        public bool ResetAtAwake;
        public int DefaultValue;

        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;
        
        public void SetValue(int value) => Value = value;

        public void SetValue(IntVariable value) => Value = value.Value;

        public void ApplyChange(int amount) => Value += amount;

        public void ApplyChange(IntVariable amount) => Value += amount.Value;
    }
}