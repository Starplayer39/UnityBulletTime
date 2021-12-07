namespace UnityBulletTime.Camera
{
    using UnityBulletTime;    
    using UnityEngine;

    [DisallowMultipleComponent]
    public class BulletTimeFpsCamera : BulletTimeCameraBase
    {
        [Header("Fps Camera")]
        [SerializeField] [InspectorName("Follow Offset")] protected Vector3 m_followOffset;
        [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
        [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] [BulletTimeVariable] protected float m_mouseSensitivity = 100.0f;
        [SerializeField] [InspectorName("Look Maximum X")] protected float m_lookMaximumX = 90.0f;
        [SerializeField] [InspectorName("Look Minimum X")] protected float m_lookMinimumX = -90.0f;

        private float m_rotationX = 0.0f;

        protected override void Start()
        {
            base.Start();

            Init();
        }

        private void Update()
        {
            Follow();
        }

        private void OnValidate()
        {
            if (gameObject.transform.parent == null)
            {
#if UNITY_EDITOR
                Debug.LogError("The FPS camera object needs to be the child object of the GameObject that owned this Fps Camera to work normally");
#endif
                return;
            }

            m_owner = gameObject.transform.parent.gameObject;
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

        public override void Follow()
        {
            m_cameraObject.transform.position = m_owner.transform.position + m_followOffset;
        }

        public override void Look(float mouseX, float mouseY)
        {
            if (m_owner != null)
            {
                float multiplier = m_isBulletTimeCamera ? Time.deltaTime : (TimeManager.Instance.IsBulletTime ? Time.deltaTime * Time.deltaTime : Time.deltaTime);               

                m_rotationX += -mouseY * m_mouseSensitivity * multiplier;
                m_rotationX = Mathf.Clamp(m_rotationX, m_lookMinimumX, m_lookMaximumX);
                m_cameraObject.transform.localRotation = Quaternion.Euler(m_rotationX, 0, 0);
                m_owner.transform.rotation *= Quaternion.Euler(0, mouseX * m_mouseSensitivity * multiplier, 0);
            }

            else
            {
#if UNITY_EDITOR
                Debug.LogError("The camera object needs to be the child object of the GameObject that owned this Fps Camera to work normally");
#endif
                return;
            }
        }
    }

}