using UnityEngine;

[RequireComponent(typeof(Camera))]
public abstract class BulletTimeCameraBase : MonoBehaviour
{
    public GameObject Owner
    {
        get
        {
            if (gameObject.transform.parent != null)
            {
#if UNITY_EDITOR
                Debug.LogError("The camera object needs to be the child object of the GameObject that owned this Fps Camera to work normally");
#endif
                return null;
            }

            else
            {
                return m_owner;
            }
        }
    }

    public GameObject CameraObject
    {
        get
        {
            if (m_cameraObject == null)
            {
                m_cameraObject = gameObject;
                return m_cameraObject;
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
                    m_cameraObject = gameObject;
                    m_cameraComponent = m_cameraObject.GetComponent<Camera>();

                    if (m_cameraComponent == null)
                    {
#if UNITY_EDITOR
                        Debug.LogWarning($"{gameObject.name} which has {GetType().Name} component needs Camera component");
#endif
                        m_cameraObject.AddComponent<Camera>();
                    }

                    return m_cameraComponent;
                }

                else
                {
                    m_cameraComponent = m_cameraObject.GetComponent<Camera>();
                    return m_cameraComponent;
                }
            }

            else return m_cameraComponent;
        }

        protected set
        {
            m_cameraComponent = value;
        }
    }    

    [Header("Camera")]    
    [SerializeField] [Tooltip("Represent should not the camera be affected by Time.TimeScale")] [InspectorName("Is Bullet Time Camera")] 
    protected bool m_isBulletTimeCamera = true;

    protected GameObject m_owner;
    protected GameObject m_cameraObject;
    protected Camera m_cameraComponent;

    protected virtual void Init()
    {
        m_cameraObject = gameObject;
        m_cameraComponent = m_cameraObject.GetComponent<Camera>();        
    }

    public abstract void Follow();    

    public abstract void Look(float mouseX, float mouseY);
}
