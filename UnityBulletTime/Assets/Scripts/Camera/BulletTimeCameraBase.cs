using UnityEngine;

public abstract class BulletTimeCameraBase : MonoBehaviour
{
    protected Camera CameraComponent
    {
        get
        {
            if (m_cameraComponent == null)
            {
                if (m_cameraObject == null)
                {
#if UNITY_EDITOR
                    Debug.LogError($"{GetType().Name} attached to the '{gameObject.name}' GameObject needs camera GameObject");
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

    [Header("Camera")]
    [SerializeField] [InspectorName("Camera Object")] protected GameObject m_cameraObject;
    [SerializeField] [Range(0.0f, 100.0f)] protected float m_followSpeed;
    [SerializeField] protected bool shouldAffectedByTimeScale = false;

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
    }

    protected abstract void Follow();

    protected abstract void FollowWithScaledTime();

    protected abstract void Aim();

    protected abstract void AimWithScaledTime();
}
