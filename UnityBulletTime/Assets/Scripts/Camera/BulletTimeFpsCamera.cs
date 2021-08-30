using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeFpsCamera : BulletTimeCameraBase
{
    [Header("Fps Camera")]
    [SerializeField] [InspectorName("Should Follow Target With Offset")] 
    [Tooltip("The camera object position will be affected by the 'Follow Offset' variable when this variable is set to true. It is recommended to set this variable to false while using Fps Camera")] 
    protected bool m_shouldFollowTargetWithOffset = false;
    [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
    [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] protected float m_mouseSensitivity = 100.0f;
    [SerializeField] [InspectorName("Look Maximum X")] protected float m_lookMaximumX = 90.0f;
    [SerializeField] [InspectorName("Look Minimum X")] protected float m_lookMinimumX = -90.0f;

    private Vector3 m_initialPosition;
    private float m_rotationX = 0.0f;    

    private void OnValidate()
    {                
        //This variable is unused in this class
        m_followSpeed = 0.0f;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {        
        m_followSpeed = 0.0f;

        if (m_shouldFollowTargetWithOffset)
        {
            Follow();
        }

        else
        {
            m_cameraObject.transform.position = m_initialPosition;
        }
    }

    protected override void Init()
    {
        base.Init();

        if (m_shouldHideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (gameObject.transform.parent == null)
        {
#if UNITY_EDITOR 
            Debug.LogError("The camera object needs to be the child object of the GameObject that uses Fps Camera");            
#endif
        }

        m_initialPosition = m_cameraObject.transform.position;
    }

    public override void Follow()
    {
        m_cameraObject.transform.position = m_targetToFollow.transform.position + m_followOffset;
    }

    public override void Look(float mouseX, float mouseY)
    {
        float mouseSensitivity = m_shouldAffectedByTimeScale ? m_mouseSensitivity * Time.deltaTime : m_mouseSensitivity * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();

        m_rotationX += -mouseY * mouseSensitivity;
        m_rotationX = Mathf.Clamp(m_rotationX, m_lookMinimumX, m_lookMaximumX);
        m_cameraObject.transform.localRotation = Quaternion.Euler(m_rotationX, 0, 0);       
        m_targetToFollow.transform.rotation *= Quaternion.Euler(0, mouseX * mouseSensitivity, 0);
    }
}
