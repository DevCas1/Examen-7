namespace Sjouke.Input
{
    using UnityEngine;
    using CodeArchitecture.Variables;

    [CreateAssetMenu(menuName = "Player Settings/Input\tSet")]
    public sealed class PlayerInputContainer : ScriptableObject
    {
        public FloatVariable Steering;
        public FloatVariable Acceleration;
        public FloatVariable Braking;
        [Space(10)]
        public bool ResetAtStart = true;
        
        private FloatVariable _defaultSteering;
        private FloatVariable _defaultAccelerationVariable;
        private FloatVariable _defaultBraking;

        private void Reset()
        {
            Steering = null;
            Acceleration = null;
            Braking = null;
        }

        private void OnEnable()
        {
            if (Steering != null) _defaultSteering = Steering;
            if (Acceleration != null) _defaultAccelerationVariable = Acceleration;
            if (Braking != null) _defaultBraking = Braking;
        }

        private void Awake()
        {
            Steering = _defaultSteering;
            Acceleration = _defaultAccelerationVariable;
            Braking = _defaultBraking;
        }

        public void AssignSteering(FloatVariable input) => Steering = input;

        public void AssignAcceleration(FloatVariable input) => Acceleration = input;

        public void AssignBraking(FloatVariable input) => Braking = input;
    }

}