namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/Double\tVariable")]
    public class DoubleVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public double Value;
        public bool ResetAtAwake;
        public double DefaultValue;
        
        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;
        
        public void SetValue(double value) => Value = value;

        public void SetValue(DoubleVariable value) => Value = value.Value;

        public void ApplyChange(double amount) => Value += amount;

        public void ApplyChange(DoubleVariable amount) => Value += amount.Value;
    }
}