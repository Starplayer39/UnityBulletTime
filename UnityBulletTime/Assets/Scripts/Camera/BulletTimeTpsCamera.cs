//Bullet Time Camera will be implemented later

namespace UnityBulletTime.Camera
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class BulletTimeTpsCamera : BulletTimeCameraBase
    {
        [Header("Tps Camera")]        
        [SerializeField] [InspectorName("Initial Offset")] protected Vector3 m_initialOffset = new Vector3(45.0f, 0.0f, 0.0f);
        [SerializeField] [InspectorName("Camera Arm Length")] [Range(0.0f, 100.0f)] protected float m_cameraArmLength;
        [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
        [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] [BulletTimeVariable] protected float m_mouseSensitivity = 100.0f;
        [SerializeField] [InspectorName("Look Maximum X")] protected float m_lookMaximumX = 50.0f;
        [SerializeField] [InspectorName("Look Minimum X")] protected float m_lookMinimumX = -50.0f;
        [SerializeField] [InspectorName("Distance")] protected float m_distance = 5.0f;

        protected Vector3 m_orbitAngles;

        protected override void Start()
        {
            base.Start();

            Init();
        }

        private void LateUpdate()
        {
            Follow();
        }

        protected override void Init()
        {
            base.Init();

            if (m_shouldHideCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }            
        }

        private void OnValidate()
        {
            if (gameObject.transform.parent == null)
            {
#if UNITY_EDITOR
                Debug.LogError("The TPS camera object needs to be the child object of the GameObject that owned this Tps Camera to function properly");
#endif
                return;
            }

            m_owner = gameObject.transform.parent?.gameObject;
            m_orbitAngles = m_initialOffset;

            UpdatePosition();
        }

        public override void Follow()
        {
            UpdatePosition();
        }        

        protected void UpdatePosition()
        {
            Vector3 ownerPosition = m_owner.transform.position;
            Quaternion aimingRotation = Quaternion.Euler(m_orbitAngles);
            Vector3 aimingDirection = aimingRotation * Vector3.forward;
            Vector3 aimingPosition = ownerPosition - aimingDirection * m_distance;
            transform.SetPositionAndRotation(aimingPosition, aimingRotation);
        }

        public override void Look(float mouseX, float mouseY)
        {          
        }
    }
}
