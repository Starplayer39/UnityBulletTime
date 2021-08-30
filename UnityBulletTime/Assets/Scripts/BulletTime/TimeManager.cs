using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [Header("Bullet Time")]
    public float bulletTimeFactor = 0.05f;
    public float bulletTimeLength = 9.0f;
    public float smoothTime = 0.3f;
 
    public bool isBulletTime { get; private set; }

    private float m_initialTimeScale = 1.0f;
    private float m_currentVelocity = 0.0f;
    private bool m_isCoroutineRunning = false;

    private void OnEnable() => m_initialTimeScale = Time.timeScale;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }    

    private void Update()
    {        
        isBulletTime = !Utility.IsNearlySame(Time.timeScale, 1.0f, 0.001f);     
        if (!isBulletTime && m_isCoroutineRunning)
        {
            StopCoroutine("RecoverTimeScale");
            m_isCoroutineRunning = false;
        }
    }

    public void DoBulletTime()
    {
        if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        isBulletTime = true;
        Time.timeScale = bulletTimeFactor;
        StartCoroutine("RecoverTimeScale");
        m_isCoroutineRunning = true;
    }

    public void StartBulletTime()
    {
        if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        Time.timeScale = bulletTimeFactor;
        isBulletTime = true;        
    }

    public void StopBulletTime()
    {
        if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        if (isBulletTime)
        {
            Time.timeScale = 1.0f;
            isBulletTime = false;
        }
    }

    public void StopBulletTimeSmoothly()
    {
        if (m_isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        if (isBulletTime)
        {
            Time.timeScale = Mathf.SmoothDamp(Time.timeScale, 1.0f, ref m_currentVelocity, smoothTime);
        }
    }

    public float CalculateMultiplier()
    {
        if (isBulletTime)
            return m_initialTimeScale / Time.timeScale;
        else
            return 1.0f;
    }    

    IEnumerator RecoverTimeScale()
    {
        while (true)
        {
            if (isBulletTime)
            {
                Time.timeScale += (1.0f / bulletTimeLength) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
            }

            else break;

            isBulletTime = !Utility.IsNearlySame(Time.timeScale, 1.0f, 0.001f);            

            yield return null;
        }
    }
}
