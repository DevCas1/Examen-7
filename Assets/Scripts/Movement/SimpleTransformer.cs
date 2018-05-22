namespace Sjouke.Simple
{
    using UnityEngine;
    using CodeArchitecture.Variables;
    
    public sealed class SimpleTransformer : MonoBehaviour 
    {
        public Vector3Reference MoveVector;
        public BoolReference MoveAtStart;
        public Vector3Reference RotateVector;
        public BoolReference RotateAtStart;

        private bool _doMove;
        private bool _doRotate;
	    
        private void Start() => CheckPrivateValues();

        private void CheckPrivateValues()
        {
            _doMove = MoveAtStart.Value;
            _doRotate = RotateAtStart.Value;
        }
        
        private void Update () 
        {
            if (_doMove || MoveVector.Value != Vector3.zero)
                PerformTransform();
            if (_doRotate || RotateVector.Value != Vector3.zero)
                PerformRotation();
        }

        private void PerformTransform() => transform.Translate(MoveVector.Value * Time.smoothDeltaTime);

        private void PerformRotation() => transform.Rotate(RotateVector.Value * Time.smoothDeltaTime);

        public void PerformTransform(Vector3 delta) => transform.Translate(delta * Time.smoothDeltaTime);

        public void PerformRotation(Vector3 delta) => transform.Rotate(delta * Time.smoothDeltaTime);
    }
}