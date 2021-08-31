using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeTpsCamera : BulletTimeCameraBase
{
    [Header("Tps Camera")]
    [SerializeField] [InspectorName("Follow Offset")] protected Vector3 m_followOffset;
    [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
    [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] protected float m_mouseSensitivity = 100.0f;

    private Transform m_cameraTransform;
    private Vector3 m_cameraAngle;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Follow();
    }

    private void OnValidate()
    {
        Init();        
    }

    protected override void Init()
    {
        base.Init();

        if (m_shouldHideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        m_cameraAngle = m_cameraObject.transform.eulerAngles;
        m_cameraTransform = m_cameraObject.transform;
        m_cameraTransform.position = m_owner.transform.position + m_followOffset;
    }

    public override void Follow()
    {
        m_cameraTransform.position = m_owner.transform.position + m_followOffset;
    }

    public override void Look(float mouseX, float mouseY)
    {        
    }
}
