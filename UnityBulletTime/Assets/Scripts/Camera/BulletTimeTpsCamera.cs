using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeTpsCamera : BulletTimeCameraBase
{
    [Header("Tps Camera")]
    [SerializeField] [InspectorName("Follow Offset")] protected Vector3 m_followOffset;
    [SerializeField] [InspectorName("Should Hide Cursor")] protected bool m_shouldHideCursor = true;
    [SerializeField] [InspectorName("Mouse Sensitivity")] [Range(0.0f, 1000.0f)] protected float m_mouseSensitivity = 100.0f;
    [SerializeField] [InspectorName("Look Maximum X")] protected float m_lookMaximumX = 90.0f;
    [SerializeField] [InspectorName("Look Minimum X")] protected float m_lookMinimumX = -90.0f;       

    private void Start()
    {
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

    public override void Follow()
    {
        m_cameraObject.transform.position = m_owner.transform.position + m_followOffset;
    }

    public override void Look(float mouseX, float mouseY)
    {        
    }
}
