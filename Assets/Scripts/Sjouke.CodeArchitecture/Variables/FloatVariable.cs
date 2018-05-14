namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/Float\tVariable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public float Value;
        public bool ResetAtAwake;
        public float DefaultValue;

        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;
        
        public void SetValue(float value) => Value = value;

        public void SetValue(FloatVariable value) => Value = value.Value;

        public void ApplyChange(float amount) => Value += amount;

        public void ApplyChange(FloatVariable amount) => Value += amount.Value;
    }
}