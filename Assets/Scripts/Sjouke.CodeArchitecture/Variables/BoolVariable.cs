namespace Sjouke.CodeArchitecture.Variables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Variables/Bool\tVariable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(4)]
        public string DeveloperDescription = "";
#endif
        public bool Value;
        public bool ResetAtAwake;
        public bool DefaultValue;

        private void Awake() => Value = ResetAtAwake ? DefaultValue : Value;

        public void SetValue(bool value) => Value = value;

        public void SetValue(BoolVariable value) => Value = value.Value;
    }
}