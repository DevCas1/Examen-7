namespace Sjouke.Camera
{
    using UnityEngine;
    public enum RotationAxis { X, Y, Z, XY, XZ, YZ}

    [System.Serializable]
    public sealed class FollowSettings
    {
        public bool UseInEditorOffset;
        [Tooltip("! Has no effect if UseInEditorOffset is true !")]public Vector3 FollowOffset;
        public bool SmoothFollow = true;
        [Range(1, 10)] public float FollowSpeed = 5;
    }

    [System.Serializable]
    public sealed class RotateSettings
    {
        public bool RotateWithTransform;
        public RotationAxis LockedAxis;
        public bool SmoothRotate = true;
        [Range(1f, 100f)] public float RotateSpeed;
    }

    public class ObjectFollow : MonoBehaviour
    {
        public Transform TransformToFollow;
        public bool SnapPositionAtStart = true;
        public FollowSettings followSettings = new FollowSettings();
        [Tooltip("! CHANGING THESE SETTINGS HAVE NO EFFECT !")]
        public RotateSettings rotateSettings = new RotateSettings();

        private Vector3 _inEditorOffset;
        
        private void Start()
        {
            if (followSettings.UseInEditorOffset)
                CalculateInEditorOffset();

            if (SnapPositionAtStart)
                SetObjectPosition();
        }

        private void CalculateInEditorOffset()
        {
            _inEditorOffset = TransformToFollow.position - this.transform.position;
        }

        private void SetObjectPosition()
        {
            this.transform.position = CalculateFollowPosition();
        }

        private void Update()
        {
            if (followSettings.SmoothFollow)
                PerformSmoothFollow();
            else 
                PerformInstantFollow();

            //if (!rotateSettings.RotateWithTransform) return;

            //if (rotateSettings.SmoothRotate)
            //    PerformSmoothRotation();
            //else 
            //    PerformInstantRotation();
        }

        private Vector3 CalculateFollowPosition()
        {
            return TransformToFollow.position + (followSettings.UseInEditorOffset ? _inEditorOffset : followSettings.FollowOffset);
        }

        private void PerformSmoothFollow()
        {
            this.transform.position = Vector3.Lerp(transform.position, CalculateFollowPosition(), 1 - Mathf.Exp(-followSettings.FollowSpeed * Time.smoothDeltaTime));
        }

        private void PerformInstantFollow()
        {
            this.transform.position = CalculateFollowPosition();
        }

        private Quaternion CalculateFollowRotation()
        {
            bool rotateX = rotateSettings.LockedAxis == RotationAxis.X || rotateSettings.LockedAxis == RotationAxis.XY || rotateSettings.LockedAxis == RotationAxis.XZ;
            bool rotateY = rotateSettings.LockedAxis == RotationAxis.Y || rotateSettings.LockedAxis == RotationAxis.XY || rotateSettings.LockedAxis == RotationAxis.YZ;
            bool rotateZ = rotateSettings.LockedAxis == RotationAxis.Z || rotateSettings.LockedAxis == RotationAxis.XZ || rotateSettings.LockedAxis == RotationAxis.YZ;

            return Quaternion.Euler(new Vector3(rotateX ? TransformToFollow.rotation.x : transform.rotation.x, 
                                                rotateY ? TransformToFollow.rotation.y : transform.rotation.y,
                                                rotateZ ? TransformToFollow.rotation.z : transform.rotation.z));
        }

        private void PerformSmoothRotation()
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, CalculateFollowRotation(), Time.smoothDeltaTime * rotateSettings.RotateSpeed);
        }

        private void PerformInstantRotation()
        {
            this.transform.rotation = CalculateFollowRotation();
        }
    }
}