//Bullet Time Camera will be implemented later

namespace UnityBulletTime.Camera
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class BulletTimeTpsCamera : BulletTimeCameraBase
    {
        [Header("Tps Camera")]
        [SerializeField] [InspectorName("Aim Target")] protected Transform m_aimTarget;
        [SerializeField] [InspectorName("Camera Arm Length")] [Range(0.0f, 100.0f)] protected float m_cameraArmLength;
        [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
        [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] [BulletTimeVariable] protected float m_mouseSensitivity = 100.0f;
        [SerializeField] [InspectorName("Look Maximum X")] protected float m_lookMaximumX = 50.0f;
        [SerializeField] [InspectorName("Look Minimum X")] protected float m_lookMinimumX = -50.0f;

        protected override void Start()
        {
            base.Start();

            Init();
        }

        private void Update()
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
        }

        public override void Follow()
        {            
        }        

        public override void Look(float mouseX, float mouseY)
        {          
        }
    }
}
