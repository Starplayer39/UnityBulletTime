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

    private float currentVelocity = 0.0f;

    private bool isCoroutineRunning = false;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update()
    {        
        isBulletTime = !Utility.IsNearlySame(Time.timeScale, 1.0f, 0.001f);     
        if (!isBulletTime && isCoroutineRunning)
        {
            StopCoroutine("RecoverTimeScale");
            isCoroutineRunning = false;
        }
    }

    public void DoBulletTime()
    {
        if (isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        isBulletTime = true;
        Time.timeScale = bulletTimeFactor;
        StartCoroutine("RecoverTimeScale");
        isCoroutineRunning = true;
    }

    public void StartBulletTime()
    {
        if (isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        Time.timeScale = bulletTimeFactor;
        isBulletTime = true;        
    }

    public void StopBulletTime()
    {
        if (isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        if (isBulletTime)
        {
            Time.timeScale = 1.0f;
            isBulletTime = false;
        }
    }

    public void StopBulletTimeSmoothly()
    {
        if (isCoroutineRunning) { StopCoroutine("RecoverTimeScale"); }

        if (isBulletTime)
        {
            Time.timeScale = Mathf.SmoothDamp(Time.timeScale, 1.0f, ref currentVelocity, smoothTime);
        }
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
