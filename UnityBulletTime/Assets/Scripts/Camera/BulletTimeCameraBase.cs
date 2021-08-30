using UnityEngine;

public abstract class BulletTimeCameraBase : MonoBehaviour
{    
    public GameObject CameraObject
    {
        get
        {
            if (m_cameraObject == null)
            {
#if UNITY_EDITOR
                Debug.LogError($"{GetType().Name} attached to the '{gameObject.name}' GameObject needs camera GameObject");
#endif
                return null;
            }

            else return m_cameraObject;
        }

        protected set { m_cameraObject = value; }
    }

    public Camera CameraComponent
    {
        get
        {
            if (m_cameraComponent == null)
            {
                if (m_cameraObject == null)
                {
#if UNITY_EDITOR
                    Debug.LogError($"{GetType().Name} attached to the '{gameObject.name}' GameObject needs a camera GameObject");
#endif
                    return null;
                }

                else
                {
                    m_cameraComponent = m_cameraObject.GetComponent<Camera>();
                    return m_cameraComponent;
                }
            }

            else return m_cameraComponent;
        }
    }

    public GameObject TargetToFollow
    {
        get
        {
            if (m_targetToFollow == null)
            {
#if UNITY_EDITOR
                Debug.LogError($"{GetType().Name} attached to the '{gameObject.name}' GameObject needs a target GameObject to follow");
#endif
                return null;
            }

            else
            {
                return m_targetToFollow;
            }
        }
    }    

    [Header("Camera")]
    [SerializeField] [InspectorName("Camera Object")] protected GameObject m_cameraObject;
    [SerializeField] [InspectorName("Target To Follow")] protected GameObject m_targetToFollow;    
    [SerializeField] [InspectorName("Follow Offset")] protected Vector3 m_followOffset;    
    [SerializeField] [Range(0.0f, 100.0f)] protected float m_followSpeed;
    [SerializeField] protected bool m_shouldAffectedByTimeScale = false;

    protected Camera m_cameraComponent;

    protected virtual void Init()
    {
        if (m_cameraObject == null)
        {
#if UNITY_EDITOR
            Debug.LogError($"{GetType().Name} attached to the '{gameObject.name}' GameObject needs camera GameObject");
#endif
            return;
        }

        else
        {
            m_cameraComponent = m_cameraObject.GetComponent<Camera>();
        }

        m_followSpeed = m_shouldAffectedByTimeScale ? m_followSpeed * Time.deltaTime : m_followSpeed * Time.deltaTime * TimeManager.Instance.CalculateMultiplier();
    }

    public abstract void Follow();    

    public abstract void Look(float mouseX, float mouseY);
}
