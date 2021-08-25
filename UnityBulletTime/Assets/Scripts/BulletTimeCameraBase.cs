using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTimeCameraBase : MonoBehaviour
{
    public GameObject CameraObject 
    {
        get { return m_cameraObject; }
            
        set
        {
            SetCamera(value);
        }
    }

    public GameObject ObjectToFollow
    {
        get { return m_objectToFollow; }
        set 
        {
            if (value != null)
                value = m_objectToFollow;
            //TODO: Change target to follow
        }
    }

    public GameObject ObjectToAim
    {
        get { return m_objectToAim; }
        set 
        {
            if (value != null)
                value = m_objectToAim;
            //TODO: Change target to aim
        }
    }

    public Camera CameraComponent 
    {   get { return m_cameraComponent; } 
        private set { value = m_cameraComponent; } 
    }

    public float MouseSensitivity
    {
        get { return m_mouseSensitivity; }
        set { value = m_mouseSensitivity; }
    }

    protected float m_mouseSensitivity = 100.0f;
    protected float m_bulletTimeMultiplier;

    private GameObject m_objectToFollow;
    private GameObject m_objectToAim;
    private GameObject m_cameraObject;
    private Camera m_cameraComponent;    

    protected virtual void Init()
    {
        if (m_cameraObject != null) m_cameraComponent = CameraObject.GetComponent<Camera>();

#if UNITY_EDITOR
        if (m_cameraObject == null) Debug.LogError($"Camera object of the 'BulletTimeCameraBase' component attached to the {gameObject.name} GameObject is null");
        if (m_cameraComponent == null) Debug.LogError($"Camera component of the 'BulletTimeCameraBase' component attached to the {gameObject.name} GameObject is null");
        if (m_objectToFollow == null) Debug.LogError($"'BulletTimeCameraBase' component attached to the {gameObject.name} GameObject has no GameObject to follow");        
#endif        

        if (m_objectToAim == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"'BulletTimeCameraBase' component attached to the {gameObject.name} GameObject has no specified GameObject to aim. It will automatically aim the GameObject which is currently followed by this camera");
#endif
            m_objectToAim = m_objectToFollow;
        }

        m_bulletTimeMultiplier = TimeManager.Instance.CalculateMultiplier();
    }

    protected virtual void Follow()
    {
        //TODO: Follow m_objectToFollow
    }

    protected virtual void AimTarget()
    {
        //TODO: Aim m_objectToAim
    }

    public void ChangeCameraDirectly(GameObject camera)
    {                
        //TODO: Change camera directly
    }

    public void ChangeCameraDirectly(Camera camComponent)
    {
        GameObject camera = camComponent.gameObject;
        //TODO: Change camera directly
    }

    public void ChangeCameraSmoothly(GameObject camera)
    {
        //TODO: Change camera smoothly
    }

    public void ChangeCameraSmoothly(Camera camComponent)
    {
        GameObject camera = camComponent.gameObject;
        //TODO: Change camera smoothly
    }


    protected void SetCamera(GameObject camera)
    {
        if (camera == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"Camera to set as camera object of the 'BulletTimeCameraBase' component attached to the {gameObject.name} GameObject is null");
#endif
            return;
        }        

        Camera camComponent = camera.GetComponent<Camera>();

        if (camComponent == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"{camera.name} has no Camera component");
#endif
            return;
        }

        CameraObject = camera;
        m_cameraComponent = camComponent;
        CameraComponent = m_cameraComponent;
    }

    protected void SetCamera(Camera camComponent)
    {
        if (camComponent == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"Camera component attached to the {camComponent.gameObject.name} passed as the parameter is null");
#endif
            return;
        }

        CameraObject = camComponent.gameObject;
        m_cameraComponent = camComponent;
    }    
}
